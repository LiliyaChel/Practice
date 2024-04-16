-----------------------------------------------------------------------------
-- Просмотр зависимостей между объектами  --
-----------------------------------------------------------------------------



/*Просмотреть все зависимости в таблице*/
SELECT
    o1.object_id,
    o1.object_name
    || ' '
    || o1.object_type,
    o2.object_id,
    o2.object_name
    || ' '
    || o2.object_type
FROM
         public_dependency p
    JOIN user_objects  o1 ON ( p.object_id = o1.object_id )
    JOIN all_objects  o2 ON ( p.referenced_object_id = o2.object_id );

/*Основной код*/
CREATE OR REPLACE PROCEDURE show_references AS

    CURSOR cur_ref IS -- Курсор для выборки всех стартовых, дочерних значений зависимостей и их родительских значений
    SELECT DISTINCT
        o1.object_id          id, --ID объекта
        o1.object_name 
        || ' '
        || o1.object_type     str -- Описание объекта (имя и тип)
    FROM
             public_dependency p -- Предсавление, создержащие зависимости между объектами по ID
        JOIN user_objects  o1 ON ( p.object_id = o1.object_id )
        JOIN all_objects   o2 ON ( p.referenced_object_id = o2.object_id ); -- user_objects в show_references_useronly

    refs           cur_ref%rowtype; -- Переменная для выгрузки курсора
    TYPE all_refs IS -- Тип данных для таблицы для хранения результатов работы курсора
        TABLE OF VARCHAR2(200) INDEX BY PLS_INTEGER; 
    curr_all_refs  all_refs; -- Таблица для хранения результатов работы курсора
    currel         PLS_INTEGER; -- Текущая строка таблицы

    PROCEDURE sub_ref ( -- Рекурсивная подпрограмма, вызгужающая все родительские значения для зависимого объекта
        child_id  NUMBER, -- ID объекта, для которого ищутся зависимости
        old_str   VARCHAR2 -- Строка с уже созданной до этого цепочкой зависимостей
    ) AS

        CURSOR cur_subref ( -- Курсор для выборки всех родительских значений для текущего дочернего
            sub_id IN NUMBER
        ) IS
        SELECT DISTINCT
            o2.object_id          id, -- ID объекта
            o2.object_name
            || ' '
            || o2.object_type     str -- Описание объекта (имя и тип)
        FROM
                 public_dependency p
            JOIN all_objects  o1 ON ( p.object_id = o1.object_id ) -- user_objects в show_references_useronly
            JOIN all_objects  o2 ON ( p.referenced_object_id = o2.object_id ) -- user_objects в show_references_useronly
        WHERE
            p.object_id = sub_id;

        subrefs           cur_subref%rowtype; -- Переменная для выгрузки курсора
        TYPE all_subrefs IS -- Тип данных для таблицы для хранения результатов работы курсора
            TABLE OF VARCHAR2(200) INDEX BY PLS_INTEGER;
        curr_all_subrefs  all_subrefs; -- Таблица для хранения результатов работы курсора
        sub_currel        PLS_INTEGER; -- Текущая строка таблицы
    BEGIN
        OPEN cur_subref(child_id); -- Открыть курсор
        LOOP
            FETCH cur_subref INTO subrefs; -- По всем строкам курсора
            EXIT WHEN cur_subref%notfound; -- Пока в курсоре есть строки
            curr_all_subrefs(subrefs.id) := subrefs.str; -- Перенести строку курсора в таблицу
        END LOOP;

        CLOSE cur_subref; -- Закрыть курсор
        IF curr_all_subrefs.count = 0 THEN -- Если родительских значений не нашлось
            dbms_output.put_line(old_str); -- Вывести полученную цепочку зависимостей на экран
            RETURN; -- Завершить работу подпрограммы
        END IF;

        sub_currel := curr_all_subrefs.first; -- Первый элемент ассоциативного массива
        FOR i IN 1..curr_all_subrefs.count LOOP -- По всем элементам массива
            IF ( lengthb(old_str
                        || ' Зависит от '
                        || curr_all_subrefs(sub_currel)) > 4000 ) THEN -- Если размер созданной цепочки зависимостей подходит к максимально допустимому размеру строки
                dbms_output.put_line(old_str||'...'); -- Остановить формирование цепочки и вывести на экран текущее значение
            ELSE
                IF ( instr('Зависит от ' || old_str|| ' Зависит от', 'Зависит от '||curr_all_subrefs(sub_currel) -- Если в цепочке нет цикла
                                           || ' Зависит от') = 0 ) THEN
                    sub_ref(sub_currel, old_str
                                        || ' Зависит от '
                                        || curr_all_subrefs(sub_currel)); -- Присоединить к цепочке текущее родительское значение, вызвать подпрограмму снова с новой цепочкой и переданным родительсикм значением
                ELSE -- Если возник цикл
                    dbms_output.put_line(old_str
                                        || ' Зависит от '
                                        || curr_all_subrefs(sub_currel)
                                        ||' (цикл) '); -- Присоединить к цепочке текущее родительское значение, дополнить надписью "(цикл)" и вывести на экран
                END IF;
            END IF;

            sub_currel := curr_all_subrefs.next(sub_currel); -- Перейти к следующему элементу массива
        END LOOP;

        curr_all_subrefs.DELETE; -- Очистить коллекцию записей
    END;

BEGIN
    OPEN cur_ref; -- Открыть курсор
    LOOP
        FETCH cur_ref INTO refs; -- По всем строкам курсора
        EXIT WHEN cur_ref%notfound; -- Пока в курсоре есть строки
        curr_all_refs(refs.id) := refs.str; -- Перенести строку курсора в таблицу
    END LOOP;

    CLOSE cur_ref; -- Закрыть курсор
    IF ( curr_all_refs.count = 0 ) THEN -- Если дочерних (стартовых) значений не нашлось
        dbms_output.put_line('Зависимости не нейдены'); -- Вывести сообщение и завершить работу программы
        RETURN;
    END IF;

    currel := curr_all_refs.first; -- Первый элемент ассоциативного массива
    FOR i IN 1..curr_all_refs.count LOOP -- По всем элементам массива
        sub_ref(currel, curr_all_refs(currel)); -- Вызвать подпрограмму, передав в нее текущее родительское значение
        currel := curr_all_refs.next(currel); -- Перейти к следующему элементу массива
    END LOOP;

EXCEPTION -- Обработка ошибок
    WHEN OTHERS THEN
        IF sqlcode = -20000 THEN -- Если происходит переполнение буфера
            RAISE; -- Вывести сообщение об ошибке в стандартном формате
        ELSE -- Остальные ошибки
            dbms_output.put_line('Неизвестная ошибка');
        END IF;
END;


/*Вывод в файл*/
CREATE OR REPLACE PROCEDURE show_references_tofile AS

    CURSOR cur_ref IS -- Курсор для выборки всех стартовых, дочерних значений зависимостей и их родительских значений
    SELECT DISTINCT
        o1.object_id          id, --ID объекта
        o1.object_name
        || ' '
        || o1.object_type     str -- Описание объекта (имя и тип)
    FROM
             public_dependency p -- Предсавление, создержащие зависимости между объектами по ID
        JOIN user_objects  o1 ON ( p.object_id = o1.object_id )
        JOIN all_objects   o2 ON ( p.referenced_object_id = o2.object_id ); -- user_objects в show_references_useronly

    file           utl_file.file_type; -- Дескриптор файла
    refs           cur_ref%rowtype; -- Переменная для выгрузки курсора
    TYPE all_refs IS -- Тип данных для таблицы для хранения результатов работы курсора
        TABLE OF VARCHAR2(200) INDEX BY PLS_INTEGER;
    curr_all_refs  all_refs; -- Таблица для хранения результатов работы курсора
    currel         PLS_INTEGER; -- Текущая строка таблицы

    PROCEDURE sub_ref ( -- Рекурсивная подпрограмма, вызгужающая все родительские значения для зависимого объекта
        child_id  NUMBER, -- ID объекта, для которого ищутся зависимости
        old_str   VARCHAR2 -- Строка с уже созданной до этого цепочкой зависимостей
    ) AS

        CURSOR cur_subref ( -- Курсор для выборки всех родительских значений для текущего дочернего
            sub_id IN NUMBER
        ) IS
        SELECT DISTINCT
            o2.object_id          id, -- ID объекта
            o2.object_name
            || ' '
            || o2.object_type     str -- Описание объекта (имя и тип)
        FROM
                 public_dependency p
            JOIN all_objects  o1 ON ( p.object_id = o1.object_id ) -- user_objects в show_references_useronly
            JOIN all_objects  o2 ON ( p.referenced_object_id = o2.object_id ) -- user_objects в show_references_useronly
        WHERE
            p.object_id = sub_id;

        subrefs           cur_subref%rowtype; -- Переменная для выгрузки курсора
        TYPE all_subrefs IS -- Тип данных для таблицы для хранения результатов работы курсора
            TABLE OF VARCHAR2(200) INDEX BY PLS_INTEGER;
        curr_all_subrefs  all_subrefs; -- Таблица для хранения результатов работы курсора
        sub_currel        PLS_INTEGER; -- Текущая строка таблицы
    BEGIN
        OPEN cur_subref(child_id); -- Открыть курсор
        LOOP
            FETCH cur_subref INTO subrefs; -- По всем строкам курсора
            EXIT WHEN cur_subref%notfound; -- Пока в курсоре есть строки
            curr_all_subrefs(subrefs.id) := subrefs.str; -- Перенести строку курсора в таблицу
        END LOOP;

        CLOSE cur_subref; -- Закрыть курсор
        IF curr_all_subrefs.count = 0 THEN -- Если родительских значений не нашлось
            utl_file.put_line(file, old_str); -- Вывести полученную цепочку зависимостей в файл
            RETURN; -- Завершить работу подпрограммы
        END IF;

        sub_currel := curr_all_subrefs.first; -- Первый элемент ассоциативного массива
        FOR i IN 1..curr_all_subrefs.count LOOP -- По всем элементам массива
            IF ( lengthb(old_str
                         || ' Зависит от '
                         || curr_all_subrefs(sub_currel)) > 4000 ) THEN -- Если размер созданной цепочки зависимостей подходит к максимально допустимому размеру строки
                utl_file.put_line(file, old_str || '...');-- Остановить формирование цепочки и вывести в файл текущее значение
            ELSE
                IF ( instr('Зависит от '
                           || old_str
                           || ' Зависит от',
                          'Зависит от '
                          || curr_all_subrefs(sub_currel) -- Если в цепочке нет цикла
                          || ' Зависит от') = 0 ) THEN
                    sub_ref(sub_currel, old_str
                                        || ' Зависит от '
                                        || curr_all_subrefs(sub_currel)); -- Присоединить к цепочке текущее родительское значение, вызвать подпрограмму снова с новой цепочкой и переданным родительсикм значением
                ELSE -- Если возник цикл
                    utl_file.put_line(file, old_str
                                            || ' Зависит от '
                                            || curr_all_subrefs(sub_currel)
                                            || ' (цикл) '); -- Присоединить к цепочке текущее родительское значение, дополнить надписью "(цикл)" и вывести в файл
                END IF;
            END IF;

            sub_currel := curr_all_subrefs.next(sub_currel); -- Перейти к следующему элементу массива
        END LOOP;

        curr_all_subrefs.DELETE; -- Очистить коллекцию записей
    END;

BEGIN
    file := utl_file.fopen('STUD_PLSQL', 'chel520buff.txt', 'W');
    OPEN cur_ref; -- Открыть курсор
    LOOP
        FETCH cur_ref INTO refs; -- По всем строкам курсора
        EXIT WHEN cur_ref%notfound; -- Пока в курсоре есть строки
        curr_all_refs(refs.id) := refs.str; -- Перенести строку курсора в таблицу
    END LOOP;

    CLOSE cur_ref; -- Закрыть курсор
    IF ( curr_all_refs.count = 0 ) THEN -- Если дочерних (стартовых) значений не нашлось
        utl_file.put_line(file, 'Зависимости не нейдены'); -- Вывести в файл сообщение и завершить работу программы
        utl_file.fclose(file); -- Закрыть файл
        RETURN;
    END IF;

    currel := curr_all_refs.first; -- Первый элемент ассоциативного массива
    FOR i IN 1..curr_all_refs.count LOOP -- По всем элементам массива
        sub_ref(currel, curr_all_refs(currel)); -- Вызвать подпрограмму, передав в нее текущее родительское значение
        currel := curr_all_refs.next(currel); -- Перейти к следующему элементу массива
    END LOOP;

    utl_file.fclose(file); -- Закрыть файл
EXCEPTION -- Обработка ошибок
    WHEN OTHERS THEN
        dbms_output.put_line('Неизвестная ошибка');
END;

/*Вывод на экран*/
DECLARE -- Анонимный блок просмотра имеющихся файлов
    file    utl_file.file_type; --Дескриптор
    buffer  VARCHAR2(4000); -- Буфер для чтения строки из файла
BEGIN
    file := utl_file.fopen('STUD_PLSQL', 'chel520buff.txt', 'r'); -- Открываем файл буфера для чтения
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