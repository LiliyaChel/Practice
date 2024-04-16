-----------------------------------------------------------------------------
-- Математический пакет работы с полиномами произвольного числа переменных --
-----------------------------------------------------------------------------
CREATE OR REPLACE PACKAGE polynoms IS
    TYPE element IS --Одночлен
        TABLE OF NUMBER(10, 2) INDEX BY VARCHAR2(1);
    TYPE polynom IS --Многочлен
        TABLE OF element INDEX BY VARCHAR2(20);

    FUNCTION pol_summ ( --Сумма многочленов
        pol1   polynom,
        pol2   polynom
    ) RETURN polynom;

    FUNCTION pol_multy ( --Умножение многочлена на число
        pol    polynom,
        coef   NUMBER
    ) RETURN polynom;

    FUNCTION pol_diff ( --Вычитание многочленов
        pol1   polynom,
        pol2   polynom
    ) RETURN polynom;

    FUNCTION pol_string ( --Вывод многочлена в строку
        pol polynom
    ) RETURN VARCHAR2;

    FUNCTION pol_multy ( --Умножение многочлена на многочлен
        pol1   polynom,
        pol2   polynom
    ) RETURN polynom;

    FUNCTION pol_pow ( --Возведение многочлена в степень (целое положительное число)
        pol    polynom,
        coef   PLS_INTEGER
    ) RETURN polynom;

    FUNCTION sym_func ( --Вызов операции по символу, а не названию)
        sym    VARCHAR2,
        pol1   polynom,
        pol2   polynom
    ) RETURN polynom;

    FUNCTION pol_simpl ( --Приведение строки к многочлену
        strng VARCHAR2
    ) RETURN polynom;

END;

CREATE OR REPLACE PACKAGE BODY polynoms IS

    FUNCTION el_cut ( --Служебная функция. Выделение одночлена из начала строки, если возможно
        str IN OUT VARCHAR2
    ) RETURN element IS

        symb       VARCHAR(1);
        oldsymb    VARCHAR(1);
        nums       BINARY_FLOAT;
        nums2      PLS_INTEGER;
        strnums    VARCHAR2(10);
        polindex   VARCHAR2(20);
        currel     element;
        pos        PLS_INTEGER;
    BEGIN
		--Сохранение унарного минуса
        IF symb = '-' THEN
            nums := -1;
            str := substr(str, 2);
        ELSE
            nums := 1;
        END IF;
		-- Сохранение коэффициента
        FOR i IN 1..length(str) LOOP -- До конца строки
            symb := substr(str, i, 1); -- Посимвольно
            IF ( symb >= '0' AND symb <= '9' ) OR symb = ',' THEN --Выделяем цифры и разделитель 
                strnums := strnums || symb; --Присоединяем к предыдущим символам коэффициента
            ELSE -- Если коэф.кончился - выход
                pos := i;
                EXIT;
            END IF;

        END LOOP;
		-- Если нашли коэффициент. Если нет = 1
        IF strnums IS NOT NULL THEN
            nums := nums * to_number(strnums); -- Конвертировать коэф. в число
        END IF;

        str := substr(str, pos); -- Удалить коэф. из строки
        currel(0) := nums; -- Записать коэфф. в одночлен
        IF length(str) > 0 THEN -- Если это было не просто число в конце строки
            FOR i IN 1..length(str) LOOP -- До конца строки
                symb := substr(str, i, 1); -- Выделить переменную
                IF ( symb >= 'a' AND symb <= 'z' ) THEN -- Если новая переменная
					--Внести старую переменнную, если она была
                    IF oldsymb IS NOT NULL THEN 
                        IF strnums IS NOT NULL THEN
                            currel(oldsymb) := to_number(strnums); -- Сохраняем степень переменной
                        ELSE
                            currel(oldsymb) := 1; -- Если степени не бло, это степень 1
                        END IF;
                    END IF;
					-- Запомнить данные о новой переменной
                    strnums := ''; -- Обнуляем переменные
                    oldsymb := symb;
                    polindex := polindex || symb; -- Создаем индекс одночлена в полиноме (все переменные со степенями)
                ELSE
                    IF ( symb >= '0' AND symb <= '9' ) THEN -- Если это число - часть степени переменной
                        strnums := strnums || symb; -- Добавляем к предыдущим числам
                        polindex := polindex || symb;
                    ELSE -- Закончить, если не часть одночлена
                        pos := i; -- Сохраняем индекс конца одночлена
                        EXIT;
                    END IF;
                END IF;

            END LOOP;
			--Внести последнюю переменнную (как в цикле)
            IF oldsymb IS NOT NULL THEN
                IF strnums IS NOT NULL THEN
                    currel(oldsymb) := to_number(strnums);
                ELSE
                    currel(oldsymb) := 1;
                END IF;

            END IF;
			-- Обрезать строку до конца одночлена
            IF ( length(str) > 1 ) THEN
                str := substr(str, pos);
            ELSE
                str := '';
            END IF;

        END IF;
		-- Вернуть получившийся одночлен
        RETURN currel;
    EXCEPTION
        WHEN OTHERS THEN
            dbms_output.put_line('Преобразование элемента не удалось');
    END;

    FUNCTION getid ( -- Служебная функция. Получить индекс одночлена для многочлена (часть одночлена без коэффициента, в строковом виде) 
        el element
    ) RETURN VARCHAR2 IS
        id     VARCHAR2(1);
        name   VARCHAR2(20);
    BEGIN
	--Если одночлен не пустой
        IF el.count > 0 THEN
            id := el.first;
			-- По всем элементам (кроме первого, коэф.) (переменным) одночлена
            FOR i IN 1..el.count - 1 LOOP
                id := el.next(id);--Добавляем к индексу имя переменной и степень, если она не 1
                name := name
                        || id
                        || CASE
                    WHEN el(id) > 1 THEN
                        el(id)
                    ELSE ''
                END;

            END LOOP;
			-- Для элемента-числа индекс - символ пробела
            IF name IS NULL THEN
                name := ' ';
            END IF;
            RETURN name;
        ELSE
            dbms_output.put_line('Пустой элемент!');
        END IF;
    EXCEPTION
        WHEN OTHERS THEN
            dbms_output.put_line('Создание ID не удалось');
    END;
-- Операция сложения
    FUNCTION pol_summ (
        pol1   polynom, -- Первое слагаемое
        pol2   polynom -- Второе слагаемое
    ) RETURN polynom IS
        currel    VARCHAR2(20);
        results   polynom;
    BEGIN
        results := pol1;
        currel := pol2.first;
		-- По всем одночленам второго слагаемого
        FOR i IN 1..pol2.count LOOP
            IF results.EXISTS(currel) THEN -- Если есть в первом элемент с таким же индексом 
                IF results(currel)('0') = -pol2(currel)('0') THEN -- Если коэф. противоположны - удалить элемент
                    results.DELETE(currel);
                ELSE -- Иначе сложить индексы
                    results(currel)('0') := results(currel)('0') + pol2(currel)('0');
                END IF;
            ELSE -- Еcли такого элемента не было - добавить
                results(currel) := pol2(currel);
            END IF;

            currel := pol2.next(currel);
        END LOOP;
		-- Если все удалилось - добавить 0
        IF results.count = 0 THEN
            results(' ')('0'):=0;
        END IF;
		-- Вернуть результат вычислений
        RETURN results;
    EXCEPTION
        WHEN OTHERS THEN
            dbms_output.put_line('Сложение не удалось');
    END;
-- Операция умножения на число
    FUNCTION pol_multy (
        pol    polynom, -- Полином
        coef   NUMBER -- Число, на которое умножать
    ) RETURN polynom IS
        currel    VARCHAR2(20);
        results   polynom;
    BEGIN
        results := pol;
		-- Если умножаем на 0 - удалить все элементы, добавить 0
        IF coef = 0 THEN
            results.DELETE();
            results(' ')('0'):=0;
        ELSE -- Иначе домножаем на заданное число все коэф. полинома 
            currel := results.first;
            FOR i IN 1..results.count LOOP
                results(currel)('0') := results(currel)('0') * coef;

                currel := results.next(currel);
            END LOOP;

        END IF;
		-- Вернуть результат вычислений
        RETURN results;
    EXCEPTION
        WHEN OTHERS THEN
            dbms_output.put_line('Умножение не удалось');
    END;
-- Операция вычитания
    FUNCTION pol_diff (
        pol1   polynom, -- Уменьшаемое
        pol2   polynom -- Вычитаемое
    ) RETURN polynom IS
    BEGIN
	-- Вызываем операцию сложения, умножив предварительно вычитаемое на -1
        RETURN pol_summ(pol1, pol_multy(pol2, -1));
    EXCEPTION
        WHEN OTHERS THEN
            dbms_output.put_line('Вычитание не удалось');
    END;
-- Создание из полинома строки для вывода
    FUNCTION pol_string (
        pol polynom
    ) RETURN VARCHAR2 IS
        currel   VARCHAR2(20);
        str      VARCHAR2(100);
    BEGIN
	-- Если полиом не пустой
        IF pol.count > 0 THEN
            currel := pol.first; --Первый элемент рассмотрим отдельно на случай если полином - число
            str := CASE
                WHEN ( pol(currel)('0') = 1 ) AND ( currel != ' ' ) THEN -- Если коэф. 1 и это не число 1 - не выводим 1
                    ''
                ELSE pol(currel)('0')
            END
                   || CASE
                WHEN ( currel = ' ' ) THEN
                    ''
                ELSE currel
            END;

            FOR i IN 1..pol.count - 1 LOOP -- остальные элементы
                currel := pol.next(currel);
				-- добавляем к концу строки коэф. (не 1) и индекс
                str := str
                       ||
                    CASE
                        WHEN pol(currel)('0') > 0 THEN -- Между элементами ставим +
                            '+'
                        ELSE ''
                    END
                       ||
                    CASE
                        WHEN pol(currel)('0') = 1 THEN
                            ''
                        ELSE pol(currel)('0')
                    END
                       || currel;

            END LOOP;
			-- Вернуть получившуюся строку
            RETURN str;
        ELSE -- Если пустой - вернуть пустую строку
            RETURN '';
        END IF;
    EXCEPTION
        WHEN OTHERS THEN
            dbms_output.put_line('Преобразование в строку не удалось');
    END;
-- Операция умножения полинома на полином
    FUNCTION pol_multy (
        pol1   polynom, -- Первый множитель
        pol2   polynom -- Второй множитель
    ) RETURN polynom IS

        results   polynoms.polynom;
        currel1   VARCHAR2(20);
        currel2   VARCHAR2(20);
        currel3   VARCHAR2(1);
        buffel1   element;
        buffel2   element;
        id        VARCHAR(20);
    BEGIN
        currel1 := pol1.first;
        FOR i IN 1..pol1.count LOOP -- По всем элементам первого множителя
            currel2 := pol2.first;
            FOR j IN 1..pol2.count LOOP -- По всем элементам второго множителя
                buffel1 := pol1(currel1);
                buffel2 := pol2(currel2);
                currel3 := buffel2.first;
                IF buffel1('0') * buffel2('0') <> 0 THEN -- Перемножаем коэффициенты, если результат не 0
                    buffel1('0') := buffel1('0') * buffel2('0'); -- Записываем результат умножения коэф. в первый множитель
                    FOR k IN 1..buffel2.count - 1 LOOP -- По всем переменным текущего элемента второго множителя кроме коэф.
                        currel3 := buffel2.next(currel3);
                        IF buffel1.EXISTS(currel3) THEN -- Еслитакая переменная уже есть
                            buffel1(currel3) := buffel1(currel3) + buffel2(currel3); -- сложить степени
                        ELSE
                            buffel1(currel3) := buffel2(currel3); -- если нет - добавить переменную
                        END IF;

                    END LOOP;

                    id := getid(buffel1); -- Получить индекс итогового элемента
                    IF results.EXISTS(id) THEN -- Если элемент с таким индексом уже есть в результате
                        IF results(id)('0') = -buffel1('0') THEN -- Если коэф. противоположны
                            results.DELETE(id); -- Удалить элемент
                        ELSE
                            results(id)('0') := results(id)('0') + buffel1('0'); -- Иначе сложить коэф.
                        END IF;
                    ELSE -- Если элемент с новым индексом - добавить в результат
                        results(id) := buffel1;
                    END IF;

                END IF;

                currel2 := pol2.next(currel2);
            END LOOP;

            currel1 := pol1.next(currel1);
        END LOOP;

        IF results.count = 0 THEN -- Если результат пустой - вернуть 0
            results(' ')('0'):=0;
        END IF;
        RETURN results;
    EXCEPTION
        WHEN OTHERS THEN
            dbms_output.put_line('Умножение не удалось');
    END;
-- Операция возведения в степень (целое положительное число!)
    FUNCTION pol_pow (
        pol    polynom, -- Полином для возведения в степень
        coef   PLS_INTEGER -- Степень
    ) RETURN polynom IS
        results polynom;
    BEGIN
	-- ЕСли возводим в степень 0 - верунть 1
        IF coef = 0 THEN
            results(' ')('0') := 1;
        ELSE -- Иначе - вызывае операцию умножения указанное количество раз (от 2)
            results := pol;
            FOR i IN 2..coef LOOP results := pol_multy(results, pol); -- Если степень 1 - ничего не произойдет
            END LOOP;

        END IF;
		-- Возвращает результат вычислений
        RETURN results;
    EXCEPTION
        WHEN OTHERS THEN
            dbms_output.put_line('Возведение в степень не удалось');
    END;
-- Вызов операции по ее символу
    FUNCTION sym_func (
        sym    VARCHAR2, -- Операция
        pol1   polynom, -- Первый элемент
        pol2   polynom -- Второй элемент
    ) RETURN polynom IS
        results polynom;
        ex EXCEPTION;
    BEGIN
        CASE sym 
            WHEN '+' THEN-- Сложение
                RETURN pol_summ(pol1, pol2);
            WHEN '-' THEN -- Вычитание
                RETURN pol_diff(pol1, pol2);
            WHEN '*' THEN -- Умножение
                RETURN pol_multy(pol1, pol2);
            WHEN '^' THEN -- Степень!! Принимает как степень полином-число
                IF (pol2(' ').count > 1) OR (pol2.count > 1) THEN -- Если степень - полином сложнее одного числа - ошибка.
                    RAISE ex;
                END IF;
                RETURN pol_pow(pol1, pol2(' ')('0'));
            ELSE
                RAISE ex;
        END CASE;
    EXCEPTION
        WHEN OTHERS THEN
            dbms_output.put_line('Неизвестная операция');
    END;
-- Приведение строки к полиному с упрощением и раскрытием скобок
    FUNCTION pol_simpl (
        strng VARCHAR2 -- Входная строка
    ) RETURN polynom IS
		-- Технические переменные
        results      polynom;
        TYPE subf IS -- Тип для хранения приоритетов
            TABLE OF PLS_INTEGER INDEX BY VARCHAR2(1); -- Два типа под "стеки"
        TYPE polstack IS
            TABLE OF polynom;
        TYPE symbstack IS
            TABLE OF VARCHAR2(1);
        priorf       subf; -- Список приоритетов
        str          VARCHAR2(100);
        el           element;
        pol          polynom;
        stack1       polstack := polstack(); -- Стек полиномов
        stack2       symbstack := symbstack(); -- Стек символов
        symb         VARCHAR2(1);
        symb_check   VARCHAR2(1);
        el_a         polynom;
        el_b         polynom;
        oldpr        PLS_INTEGER;
        id           VARCHAR2(1);
        name         VARCHAR2(20);
        uno          BOOLEAN := true; -- Маркер унарного минуса
        buffpol1     polynom;
        buffpol2     polynom;
        ex EXCEPTION;
    BEGIN
	-- Сохраняем исходную строку
        str := strng;
		-- Заполняем приоритеты
        priorf('(') := 4;
        priorf('^') := 3;
        priorf('*') := 2;
        priorf('+') := 1;
        priorf('-') := 1;
        WHILE length(str) > 0 LOOP -- пока строка не пустая
            symb := substr(str, 1, 1);
            CASE-- Если это очевидно элемент
                WHEN ( symb >= '0' AND symb <= '9' ) OR ( symb >= 'a' AND symb <= 'z' ) OR ( symb = '-' AND uno ) THEN
                    pol.DELETE; -- Очистить старый буффер
                    el := el_cut(str); -- Выделить элемент
                    name := getid(el); -- Получить индекс элемента
                    pol(name) := el; -- Создать полином с таким элеметом
                    stack1.extend; -- Push полином в стек полиномов
                    stack1(stack1.last) := pol;
                    uno := false; -- Унарного минуса больше быть не может пока
                ELSE
                    IF symb = ')' THEN -- Если закрывающая скобка - пока не найдется открывающая среди символов
                        WHILE ( stack2(stack2.last) != '(' ) LOOP
                            buffpol2 := stack1(stack1.last); -- Pop полином 2 из стека полиномов
                            stack1.DELETE(stack1.last);
                            buffpol1 := stack1(stack1.last); -- Pop полином 1 из стека полиномов
                            stack1.DELETE(stack1.last);
                            stack1.extend; -- Push полином-результат операции (операция - Pop операция из стека операций) в стек полиномов
                            stack1(stack1.last) := sym_func(stack2(stack2.last), buffpol1, buffpol2);

                            stack2.DELETE(stack2.last); -- Pop операция из стека операций
                        END LOOP;

                        stack2.DELETE(stack2.last);  -- Pop открывающая скобка из стека полиномов
                    ELSE 
					-- Если новая операция имеет приоритет выше предыдущей или это первая операция после начала строки или (
                        IF ( stack2.last IS NULL ) OR priorf(symb) > priorf(stack2(stack2.last)) THEN
                            stack2.extend();
                            stack2(stack2.last) := symb;  -- Push операция в стек операций
                        ELSE
                            WHILE stack2.last IS NOT NULL LOOP -- Пока остались элементы в стеке операций
                                symb_check := stack2(stack2.last); -- Pop операция из стека операций
                                stack2.DELETE(stack2.last);
								-- Если новая операция имеет приоритет выше предыдущей или предыдущая - открывающая скобка
                                IF ( symb_check = '(' ) OR ( priorf(symb_check) < priorf(symb) ) -- vice versa?
                                 THEN -- Push операция в стек операций
                                    stack2.extend();
                                    stack2(stack2.last) := symb_check;
                                    EXIT;
                                END IF;

                                buffpol2 := stack1(stack1.last); -- Pop полином 2 из стека полиномов
                                stack1.DELETE(stack1.last);
                                buffpol1 := stack1(stack1.last); -- Pop полином 1 из стека полиномов
                                stack1.DELETE(stack1.last);
                                stack1.extend();--Push полином-результат операции (операция - Pop операция из стека операций) в стек полиномов
                                stack1(stack1.last) := sym_func(symb_check, buffpol1, buffpol2);
                            END LOOP;
							-- Push операция в стек операций
                            stack2.extend();
                            stack2(stack2.last) := symb;
                        END IF;
                    END IF;

                    IF symb = '(' THEN -- После ( возможен унарный минус
                        uno := true;
                    ELSE -- В других местах - нет
                        uno := false;
                    END IF;

                    str := substr(str, 2); -- Удаляем обработанный символ
            END CASE;

        END LOOP;

        WHILE ( stack1.count > 1 ) LOOP -- Пока не останется только результат
            buffpol2 := stack1(stack1.last); -- Pop полином 2 из стека полиномов
            stack1.DELETE(stack1.last);
            buffpol1 := stack1(stack1.last); -- Pop полином 1 из стека полиномов
            stack1.DELETE(stack1.last);
            stack1.extend;--Push полином-результат операции (операция - Pop операция из стека операций) в стек полиномов
            stack1(stack1.last) := sym_func(stack2(stack2.last), buffpol1, buffpol2);

            stack2.DELETE(stack2.last); -- Pop операция из стека операций
        END LOOP;

        results := stack1(stack1.last); -- Результат - единственный элемент из стека полиномов
        IF stack1.count > 1 OR stack2.count > 0 THEN -- Если в стеке операций есть элементы или в стеке полиномов больше одного элемента - ошибка
            RAISE ex;
        END IF;
		-- Вывод результата
        RETURN results;
    EXCEPTION
        WHEN OTHERS THEN
            dbms_output.put_line('Упрощение не удалось');
    END;

END;