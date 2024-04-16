-----------------------------------------------------------------------------
-- Математический пакет работы с матрицами --
-----------------------------------------------------------------------------


/* ===========================================
				ВСПОМОГАТЕЛЬНЫЕ
============================================*/
CREATE OR REPLACE PROCEDURE createfile ( -- Процедура для создания файлов с примерами матриц
    filename  VARCHAR2, -- Имя файла
    string    VARCHAR2 -- Содержимое файла
) IS
    file  utl_file.file_type; -- Дескриптор
BEGIN
    file := utl_file.fopen('STUD_PLSQL', filename, 'W'); -- Создаем файл с указанным именем и начинаем запись
    utl_file.put_line(file, string); -- Записываем содержимое
    utl_file.fclose(file); -- Закрываем файл
END;

BEGIN -- Анонимный блок создания примеров
	createfile('chelliltest1.txt','x^2+1#x
x#1'); -- Пример 1 (успешный)
    createfile('chelliltest2.txt','x^2+1#x#x^3
x#1#x
1#2#1'); -- Пример 2 (успешный)
	createfile('chelliltest3.txt','x#0#0#x
0#x#0#0
0#0#x#0
0#0#0#x'); -- Пример 3 (успешный)
	createfile('chelliltest4.txt','x#0'); -- Пример 4 (ошибка)
	createfile('chelliltest5.txt','1,313.8x^2+5'); -- Пример 5 (успешный)
	createfile('chelliltest6.txt','1.313.8x^2+5'); -- Пример 6 (ошибка)
	createfile('chelliltest7.txt','abcdef'); -- Пример 7 (ошибка)
	createfile('chelliltest8.txt','2xabcdef'); -- Пример 8 (ошибка)
END;

DECLARE -- Анонимный блок просмотра имеющихся файлов
    file    utl_file.file_type; --Дескриптор
    buffer  VARCHAR2(100); -- Буфер для чтения строки из файла
BEGIN
    file := utl_file.fopen('STUD_PLSQL', 'chelliltest1.txt', 'r'); -- Открываем файл 1 для чтения
	LOOP -- Построчно
	BEGIN
    utl_file.get_line(file, buffer); -- Читаем следующую строку в буфер
    dbms_output.put_line(buffer); -- Выводим буфер в новой строке на экран
	EXCEPTION
            WHEN NO_DATA_FOUND THEN EXIT; -- Если данные кончились - выходим из цикла
        END;
		END LOOP;
    utl_file.fclose(file); -- Закрываем файл
	dbms_output.put_line('===='); -- Разделитель
    file := utl_file.fopen('STUD_PLSQL', 'chelliltest2.txt', 'r'); -- Открываем файл 2 для чтения
	LOOP -- Построчно
	BEGIN
    utl_file.get_line(file, buffer); -- Читаем следующую строку в буфер
    dbms_output.put_line(buffer); -- Выводим буфер в новой строке на экран
	EXCEPTION
            WHEN NO_DATA_FOUND THEN EXIT; -- Если данные кончились - выходим из цикла
        END;
		END LOOP;
    utl_file.fclose(file); -- Закрываем файл
	dbms_output.put_line('===='); -- Разделитель
    file := utl_file.fopen('STUD_PLSQL', 'chelliltest3.txt', 'r'); -- Открываем файл 3 для чтения
	LOOP -- Построчно
	BEGIN
    utl_file.get_line(file, buffer); -- Читаем следующую строку в буфер
    dbms_output.put_line(buffer); -- Выводим буфер в новой строке на экран
	EXCEPTION
            WHEN NO_DATA_FOUND THEN EXIT; -- Если данные кончились - выходим из цикла
        END;
		END LOOP;
    utl_file.fclose(file); -- Закрываем файл
	dbms_output.put_line('===='); -- Разделитель
    file := utl_file.fopen('STUD_PLSQL', 'chelliltest4.txt', 'r'); -- Открываем файл 4 для чтения
	LOOP -- Построчно
	BEGIN
    utl_file.get_line(file, buffer); -- Читаем следующую строку в буфер
    dbms_output.put_line(buffer); -- Выводим буфер в новой строке на экран
	EXCEPTION
            WHEN NO_DATA_FOUND THEN EXIT; -- Если данные кончились - выходим из цикла
        END;
		END LOOP;
    utl_file.fclose(file); -- Закрываем файл
	dbms_output.put_line('===='); -- Разделитель
    file := utl_file.fopen('STUD_PLSQL', 'chelliltest5.txt', 'r'); -- Открываем файл 5 для чтения
	LOOP -- Построчно
	BEGIN
    utl_file.get_line(file, buffer); -- Читаем следующую строку в буфер
    dbms_output.put_line(buffer); -- Выводим буфер в новой строке на экран
	EXCEPTION
            WHEN NO_DATA_FOUND THEN EXIT; -- Если данные кончились - выходим из цикла
        END;
		END LOOP;
    utl_file.fclose(file); -- Закрываем файл
	dbms_output.put_line('===='); -- Разделитель
    file := utl_file.fopen('STUD_PLSQL', 'chelliltest6.txt', 'r'); -- Открываем файл 6 для чтения
	LOOP -- Построчно
	BEGIN
    utl_file.get_line(file, buffer); -- Читаем следующую строку в буфер
    dbms_output.put_line(buffer); -- Выводим буфер в новой строке на экран
	EXCEPTION
            WHEN NO_DATA_FOUND THEN EXIT; -- Если данные кончились - выходим из цикла
        END;
		END LOOP;
    utl_file.fclose(file); -- Закрываем файл
	dbms_output.put_line('===='); -- Разделитель
    file := utl_file.fopen('STUD_PLSQL', 'chelliltest7.txt', 'r'); -- Открываем файл 7 для чтения
	LOOP -- Построчно
	BEGIN
    utl_file.get_line(file, buffer); -- Читаем следующую строку в буфер
    dbms_output.put_line(buffer); -- Выводим буфер в новой строке на экран
	EXCEPTION
            WHEN NO_DATA_FOUND THEN EXIT; -- Если данные кончились - выходим из цикла
        END;
		END LOOP;
    utl_file.fclose(file); -- Закрываем файл
	dbms_output.put_line('===='); -- Разделитель
    file := utl_file.fopen('STUD_PLSQL', 'chelliltest8.txt', 'r'); -- Открываем файл 8 для чтения
	LOOP -- Построчно
	BEGIN
    utl_file.get_line(file, buffer); -- Читаем следующую строку в буфер
    dbms_output.put_line(buffer); -- Выводим буфер в новой строке на экран
	EXCEPTION
            WHEN NO_DATA_FOUND THEN EXIT; -- Если данные кончились - выходим из цикла
        END;
		END LOOP;
    utl_file.fclose(file); -- Закрываем файл
	
END;

BEGIN -- Анонимный блок вызова основной процедуры для всех примеров
det('chelliltest1.txt'); -- Определитель по файлу 1
det('chelliltest2.txt'); -- Определитель по файлу 2
det('chelliltest3.txt'); -- Определитель по файлу 3
det('chelliltest4.txt'); -- Определитель по файлу 4
det('chelliltest5.txt'); -- Определитель по файлу 5
det('chelliltest6.txt'); -- Определитель по файлу 6
det('chelliltest7.txt'); -- Определитель по файлу 7
det('chelliltest8.txt'); -- Определитель по файлу 8
END;

/* ===========================================
				ОСНОВНАЯ
============================================*/

CREATE OR REPLACE PROCEDURE det ( --Процедура подсчета определителя
    filename VARCHAR2 -- Имя файла с расширением
) AS

    file       utl_file.file_type; -- Дескриптор
    buffer     VARCHAR2(100); -- Буфер для чтения файла построчно
    symb       VARCHAR(1); -- Буфер посимвольного считывания
    strnums    VARCHAR2(10); -- Буфер чисел в строковом виде
    coef       NUMBER(15, 5); -- Коэффициент одночлена
    pows       PLS_INTEGER; -- Степень одночлена
    pos        PLS_INTEGER; -- Конец элемента одночлена
    wordcount  PLS_INTEGER := 0; -- Количество слов до выделения одночлена
    TYPE func IS
        TABLE OF NUMBER(10, 2) INDEX BY PLS_INTEGER; -- Тип данных: Одна функция
    TYPE mrow IS
        TABLE OF func INDEX BY PLS_INTEGER; -- Тип данных: Одна строка матрицы
    TYPE matrix IS
        TABLE OF mrow INDEX BY PLS_INTEGER; -- Тип данных: Матрица
    currfunc   func; -- Текущая функция
    currrow    mrow; -- Текущая строка
    ourmatrix  matrix; -- Текущая матрица
    matrixi    PLS_INTEGER; -- Номер строки
    matrixj    PLS_INTEGER; -- Номер столбца
    formatex EXCEPTION; -- Ошибка: В матрице неправильные функции (оформление)
    conditex EXCEPTION; -- Ошибка: Матрица не соответствует условиям подсчета

    FUNCTION fsum ( -- Локальная подпрограмма: Сумма двух функций
        f1  func, -- Первое слагаемое
        f2  func -- Второе слагаемое
    ) RETURN func IS -- Результат - функция, пустая коллекция это 0
        resultf  func; -- Результат
        fi       PLS_INTEGER := 0; -- Индекс второго слагаемого
    BEGIN
        resultf := f1; -- Записываем в результат первое слагаемое
        fi := f2.first; -- Сохраняем первый индекс второго слагаемого
        FOR i IN 1..f2.count LOOP -- Цикл по всем элементам второго слагаемого
            IF resultf.EXISTS(fi) THEN -- Если в результате уже есть слагаемое с такой степенью при х
                resultf(fi) := resultf(fi) + f2(fi); -- Сложить коэффициенты, записать в результат
            ELSE
                resultf(fi) := f2(fi); -- Если слагаемого с такой степенью нет - внести в результат
            END IF;

            IF resultf(fi) = 0 THEN -- Еслив итоге сложения получился 0 - удалить полученный одночлен
                resultf.DELETE(fi);
            END IF;
            fi := f2.next(fi); -- Обновить индекс для цикла на следующий
        END LOOP;

        RETURN resultf; -- Вернуть сумму
    END;

    FUNCTION fsub ( -- Локальная подпрограмма: Разность двух функций
        f1  func, -- Уменьшаемое
        f2  func -- Вычитаемое
    ) RETURN func IS -- Результат - функция, пустая коллекция это 0
        resultf  func; -- Результат
        fi       PLS_INTEGER := 0; -- Индекс вычитаемого
    BEGIN
        resultf := f1; -- Записываем в результат уменьшаемое
        fi := f2.first; -- Сохраняем первый индекс вычитаемого
        FOR i IN 1..f2.count LOOP -- Цикл по всем элементам вычитаемого
            IF resultf.EXISTS(fi) THEN -- Если в результате уже есть уменьшаемое с такой степенью при х
                resultf(fi) := resultf(fi) - f2(fi); -- Вычесть коэффициенты, записать в результат
            ELSE
                resultf(fi) := -f2(fi); -- Если уменьшаемого с такой степенью нет - внести в результат со знаком отрицания
            END IF;

            IF resultf(fi) = 0 THEN -- Еслив итоге сложения получился 0 - удалить полученный одночлен
                resultf.DELETE(fi);
            END IF;
            fi := f2.next(fi); -- Обновить индекс для цикла на следующий
        END LOOP;

        RETURN resultf; -- Вернуть разность
    END;

    FUNCTION fmulty ( -- Локальная подпрограмма: Произведение двух функций
        f1  func, -- Первый множитель
        f2  func -- Второй множитель
    ) RETURN func IS -- Результат - функция, пустая коллекция это 0
        resultf  func; -- Результат
        fi       PLS_INTEGER; -- Индекс первого множителя
        fj       PLS_INTEGER; -- Индекс второго множителя
    BEGIN
        fi := f1.first; -- Сохраняем первый индекс первого множителя
        FOR i IN 1..f1.count LOOP -- Цикл по элементам первого множителя
            fj := f2.first; -- Сохраняем первый индекс второго множителя
            FOR j IN 1..f2.count LOOP -- Цикл по элементам второго множителя
                IF resultf.EXISTS(fi + fj) THEN -- Если произведение таких одночленов (с  такой суммой степеней) уже есть в результате
                    resultf(fi + fj) := resultf(fi + fj) + f1(fi) * f2(fj); -- Прибаляем к значению в результате произведение коэффициентов
                ELSE
                    resultf(fi + fj) := f1(fi) * f2(fj); -- Если нет такого произведения - вносим его в результат
                END IF;

                IF resultf(fi + fj) = 0 THEN -- Если получившися элемент стал равен 0, удаляем его
                    resultf.DELETE(fi + fj);
                END IF;

                fj := f2.next(fj); -- Обновить индекс для цикла по второму множителю на следующий
            END LOOP;

            fi := f1.next(fi); -- Обновить индекс для цикла по первому множителю на следующий
        END LOOP;

        RETURN resultf; -- Вернуть произведение
    END;

    PROCEDURE fshow ( -- Локальная подпрограмма: Вывод функции в виде строки на экран
        f func -- Данная функция
    ) AS
        fi      PLS_INTEGER := 0; -- Индекс одночлена функции
        string  VARCHAR2(100) := ''; -- ЯИтоговая строка
    BEGIN
        IF f.count = 0 THEN -- Если функция не содержит элементов это 0
            string := '0';
        ELSE -- Если одночлены есть
            fi := f.last; -- Начина с последнего (т.е. индексы сортируются от меньшего к большему, а выводить степень надо наоборот)
            FOR k IN 1..f.count LOOP -- Цикл по всем одночленам
                string := string -- К уже имеющейся строке присоединяем:
                          ||
                    CASE -- Если коэфициент положительный, присоединяем +
                        WHEN f(fi) > 0 THEN
                            '+'
                        ELSE ''
                    END
                          ||
                    CASE -- Если коэффициент не 1 или -1 или это число без переменной (тепень 0), присоединяем коэффициент
                        WHEN abs(f(fi)) <> 1 OR fi = 0 THEN
                            f(fi)
                        ELSE ''
                    END
                          ||
                    CASE -- Если коэффициент -1, присединяем -
                        WHEN f(fi) <> -1 THEN
                            ''
                        ELSE '-'
                    END
                          ||
                    CASE -- Если степень больше 0, присоединяем х
                        WHEN fi > 0 THEN
                            'x'
                        ELSE ''
                    END
                          || 
					CASE -- Если степень больше 1, присоединяем степень
						WHEN fi > 1 THEN
							'^' || fi
						ELSE ''
					END;

                fi := f.PRIOR(fi); -- Сдвигаем индекс для цикла на шаг назад
            END LOOP;

        END IF;

        string := ltrim(string, '+'); -- Удаляем + в начале, если он появился
        dbms_output.put_line(string); -- Выводим получившуюся строку
    END;

    FUNCTION recdet ( -- Локальная подпрограмма (рекурсивная): Вычисление определителя по первой строке
        currmatrix matrix -- Заданная матрица
    ) RETURN func IS

        minor1    matrix; -- Матрица без первой строки
        minor2    matrix; -- Матрица без первой строки и заданного столбца
        matrixi   PLS_INTEGER; -- Индекс текущей строки
        matrixj   PLS_INTEGER; -- Индекс текущего столбца
        mfirst    PLS_INTEGER; -- Индекс первой строки
        detresut  func; -- Результат расчетов
        optype    BOOLEAN := true; -- Флаг +/- в суммировании, true: +, false: -
    BEGIN
        IF currmatrix.count = 1 THEN -- Если в матрице один элемент - это определитель, вернуть его
            RETURN currmatrix(currmatrix.first)(currmatrix(currmatrix.first).first);
        ELSE -- Если в матрице больше 1 элемента
            mfirst := currmatrix.first; -- Сохраняем индекс первой строки
            minor1 := currmatrix; -- Копируем матрицу в буфер
            minor1.DELETE(mfirst); -- Удаляем из буфера первую строку
            matrixj := currmatrix(mfirst).first; -- Сохраняем первый индекс столбцов
            FOR j IN 1..currmatrix(mfirst).count LOOP -- По всем столбцам
                minor2 := minor1; -- Копируем обрезанную матрицу из первого буфера во второй
                matrixi := currmatrix.next(mfirst); -- Сохраняем второй индекс строк оригинальной матрицы (первый не нужен,мы эту строку обрезали)
                FOR i IN 2..currmatrix(mfirst).count LOOP -- Цикл по всем строкам кроме первой
                    minor2(matrixi).DELETE(matrixj); -- Удаляем элемент текущего столбца
                    matrixi := currmatrix.next(matrixi); -- Обновляем индекс строк
                END LOOP;
				-- Прибавляем или вычитаем, чередуя, начав с прибавления, произведение определителся полученной обрезанной матрицы на элемент первой строки в текущем столбце
                detresut :=
                    CASE
                        WHEN optype THEN
                            fsum(detresut, fmulty(recdet(minor2), currmatrix(mfirst)(matrixj)))
                        ELSE fsub(detresut, fmulty(recdet(minor2), currmatrix(mfirst)(matrixj)))
                    END;

                matrixj := currmatrix(mfirst).next(matrixj); -- Обновляем индекс столбцов
                minor2.DELETE; -- Очищаем буфер 2
                optype := NOT optype; -- Меняем тип операции (+/-) на противоположный
            END LOOP;

            minor1.DELETE; -- Очищаем буфер 1
            RETURN detresut; -- Возвращаем полученную сумму
        END IF;
    END;

BEGIN -- Основная программа
    file := utl_file.fopen('STUD_PLSQL', filename, 'r'); -- Открываем заданный файл для чтения
    matrixi := 0; -- Задаем стартовый индекс строк
    LOOP -- Цикл по всем строкам файла
        BEGIN
            matrixj := 0;  -- Задаем стартовый индекс столбцов (разделенных в файле #)
            utl_file.get_line(file, buffer); -- Считываем новую строку в буфер
            WHILE length(buffer) > 0 LOOP -- Цикл пока в буфере есть символы, делим строку на функции
                WHILE length(buffer) > 0 LOOP -- Цикл пока в буфере есть символы, делим функцию на одночлены
                    wordcount := length(buffer); -- Сохраняем длину строки на начало операции
                    coef := 0; -- Стартовые параметры
                    pows := 0;
                    symb := '';
                    strnums := '';
                    pos := 1;
                    symb := substr(buffer, 1, 1); -- Выделяем первый символ
                    IF symb = '#' THEN -- Если это # функция кончилась
                        buffer := substr(buffer, 2); -- Символ удаляем
                        EXIT; -- Выходим из цикла
                    END IF;

                    IF symb = '-' THEN -- Если это -
                        coef := -1; -- Коэффициент отрицательный
                        buffer := substr(buffer, 2); -- Символ удаляем
                    ELSE
                        IF symb = '+' THEN -- Если это +
                            buffer := substr(buffer, 2); -- Символ удаляем
                        END IF;
                    END IF;

                    FOR j IN 1..length(buffer) LOOP -- Цикл: пока удается выделять элементы числа: запятые, точку и цифры
                        symb := substr(buffer, j, 1);
                        IF (
                            symb >= '0'
                            AND symb <= '9'
                        ) OR symb = ',' OR symb = '.' THEN
                            strnums := strnums || symb; -- Подходящие символы прибавляем к буферу
                        ELSE
                            pos := j; --Сохраняем позицию неподходящего символа
                            EXIT;
                        END IF;

                    END LOOP;

                    coef := ( -- Составляем коэффициент
                        CASE coef -- Если ранее нашли минус, домножаем на -1
                            WHEN -1 THEN
                                -1
                            ELSE 1
                        END
                    ) * (
                        CASE -- Если нашли строку с числом, ковертируем в число и домножаем на нее
                            WHEN strnums IS NOT NULL THEN
                                to_number(replace(replace(strnums, ',', ''), '.', ','))
                            ELSE 1 -- Иначе домножаем на 1
                        END
                    ); -- Неправильно написанное число вызовет обработанную ошибку формата

                    IF length(buffer) = length(strnums) THEN -- Если ранее считанные цифры занимали всю строку
                        buffer := ''; -- Очищаем буфер строки
                        currfunc(0) := coef; -- Сохраняем полученный коэффициент под индексом 0 (без степени)
                        CONTINUE; -- Переходим к следующей итерации цикла
                    ELSE 
                        buffer := substr(buffer, pos); -- Если строка длиннее - удаляем найденный коэффициент
                    END IF;

                    symb := substr(buffer, 1, 1); -- Выделяем следующий символ
                    IF symb <> 'x' THEN -- Если это не х
                        IF length(buffer) = wordcount THEN -- И не выполнено ни одно из предыдущих условий, вызывается ошибка формата
                            RAISE formatex;
                        END IF;
                        currfunc(0) := coef; -- Сохраняем полученный коэффициент под индексом 0 (без степени) 
                        CONTINUE; -- Переходим к следующей итерации цикла
                    END IF;

                    IF length(buffer) = 1 THEN -- Если ранее считанный x это вся строка
                        buffer := ''; -- Очищаем буфер строки
                        currfunc(1) := coef; -- Сохраняем полученный коэффициент под индексом 1
                        CONTINUE; -- Переходим к следующей итерации цикла
                    ELSE
                        buffer := substr(buffer, 2); -- Иначе удаляем x  из строки
                    END IF;

                    symb := substr(buffer, 1, 1); -- Выделяем следующий символ
                    IF symb <> '^' THEN -- Если это не знак степени
                        IF length(buffer) = wordcount THEN -- И не выполнено ни одно из предыдущих условий, вызывается ошибка формата
                            RAISE formatex;
                        END IF;
                        currfunc(1) := coef; -- Сохраняем полученный коэффициент под индексом 1
                        CONTINUE; -- Переходим к следующей итерации цикла
                    END IF;

                    buffer := substr(buffer, 2); -- Удаляем ^ из строки
                    pos := 1; -- Очищаем переменные для выделения цифр из строки
                    strnums := '';
                    FOR k IN 1..length(buffer) LOOP -- Цикл: пока возможно выделять цифры (степени целые и без разделителей) до конца строки
                        symb := substr(buffer, k, 1); -- Выделяем один символ
                        IF (
                            symb >= '0'
                            AND symb <= '9'
                        ) THEN
                            strnums := strnums || symb; -- Подходящий символ приписываем в конец строки цифр
                        ELSE -- Если символ не подходит
                            pos := k; -- Сохраняем позицию неподходящего символа
                            EXIT; -- Выходим из цикла
                        END IF;

                    END LOOP;

                    pows := to_number(strnums); -- Конвертируем полученные цифры в значение степени. Ошибка конвертации вызовет обработанную ошибку формата
                    currfunc(pows) := coef; -- Добавлем подсчитанный выше коэффициент по индексу полученной степени
                    IF length(buffer) = length(strnums) THEN -- Если были считанны все символы до конца строки
                        buffer := ''; -- Очищаем буфер
                    ELSE -- Иначе удаляем степень из буфера
                        buffer := substr(buffer, pos);
                    END IF;

                    IF length(buffer) = wordcount THEN -- Если за всю итерацию строка не изменилась - вызывается ошибка формата
                        RAISE formatex;
                    END IF;
                END LOOP;

                matrixj := matrixj + 1; -- Увеличение индекса функций на 1
                currrow(matrixj) := currfunc; -- Запись новой функции в строку функций
                currfunc.DELETE; -- Очистка текущей функции
            END LOOP;

            matrixi := matrixi + 1; -- Увеличение индекса строк на 1
            ourmatrix(matrixi) := currrow; -- Запись текущей строки в матрицу
            currrow.DELETE; -- Очистка текущей строки
        EXCEPTION -- Выход из цикла когда кончаются данные в файле
            WHEN no_data_found THEN
                EXIT;
        END;
    END LOOP;

    utl_file.fclose(file); -- Закрываем файл
    IF ourmatrix.count = 0 THEN -- Если в итоге матрица оказалась пустой, вызыввется ошибка формата
        RAISE formatex;
    END IF;
    matrixi := ourmatrix.first; -- Сохранение первого индекса строк
    FOR i IN 1..ourmatrix.count LOOP -- По всем строкам матрицы
        IF ourmatrix.count <> ourmatrix(matrixi).count THEN --Если чсло строк отличается от числа функций (столбцов) в лбой строке, вызывается ошибка вида матрицы
            RAISE conditex;
        END IF;

        matrixi := ourmatrix.next(matrixi); -- Обновление текущего индекса строки
    END LOOP;
	-- Основное действи
    fshow(recdet(ourmatrix)); -- Вызов рекурсивной подпрограммы подсчета определителя внутри вызова процедуры печати функции
EXCEPTION -- Обработка ошибок
    WHEN formatex OR invalid_number THEN -- Ошибки неверно вынесенных данных в матрицу
        dbms_output.put_line('Неверно внесены значения в матрицу');
    WHEN conditex THEN -- Ошибка вида матрицы
        dbms_output.put_line('Матрица не квадратная');
    WHEN OTHERS THEN
        IF sqlcode = -6502 OR sqlcode = -6512 THEN -- Ошибки конвертации чисел
            dbms_output.put_line('Неверно внесены значения в матрицу');
        ELSE -- Остальные ошибки
            dbms_output.put_line('Неизвестная ошибка');
        END IF;
END;