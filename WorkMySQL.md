# Работа с репозиторием MySQL


7. В подключенном MySQL репозитории создать базу данных “Друзья
человека”.

mysql> CREATE DATABASE Human_Friends;
Query OK, 1 row affected (0,03 sec)

mysql> SHOW DATABASES;


| Database           |
|--------------------|
| Human_Friends      |
| information_schema |
| mysql              |
| performance_schema |
| sys                |


5 rows in set (0,05 sec)

8. Создать таблицы с иерархией из диаграммы в БД.

## выполнение:

mysql> CREATE TABLE IF NOT EXISTS dog ( iddog INT PRIMARY KEY NOT NULL AUTO_INCREMENT, name VARCHAR(45) NOT NULL, birthd
ay DATETIME NOT NULL, skill VARCHAR(45) NULL);

Query OK, 0 rows affected (0,04 sec)

mysql> CREATE TABLE IF NOT EXISTS hamstel ( idhamstel INT PRIMARY KEY NOT NULL AUTO_INCREMENT, name VARCHAR(45) NOT NULL
, birthday DATETIME NOT NULL, skill VARCHAR(45) NULL);

Query OK, 0 rows affected (0,03 sec)

mysql> CREATE TABLE IF NOT EXISTS camel ( idcamel INT PRIMARY KEY NOT NULL AUTO_INCREMENT, name VARCHAR(45) NOT NULL, bi
rthday DATETIME NOT NULL, skill VARCHAR(45) NULL);

Query OK, 0 rows affected (0,03 sec)

mysql> CREATE TABLE IF NOT EXISTS horses ( idchorses INT PRIMARY KEY NOT NULL AUTO_INCREMENT, name VARCHAR(45) NOT NULL,
 birthday DATETIME NOT NULL, skill VARCHAR(45) NULL);

Query OK, 0 rows affected (0,04 sec)

mysql> CREATE TABLE IF NOT EXISTS donkey ( iddonkey INT PRIMARY KEY NOT NULL AUTO_INCREMENT, name VARCHAR(45) NOT NULL,
birthday DATETIME NOT NULL, skill VARCHAR(45) NULL);

Query OK, 0 rows affected (0,04 sec)

mysql> SHOW TABLES;

| Tables_in_Human_Friends |
|-------------------------|
| camel                   |
| cat                     |
| dog                     |
| donkey                  |
| hamstel                 |
| horses                  |

6 rows in set (0,00 sec)


9. Заполнить низкоуровневые таблицы именами(животных), командами которые они выполняют и датами рождения.

<<<<<<< HEAD
## выполнение:
=======
>>>>>>> 2c4c522562f56819293b13fd7e8ac17921d6d69a

mysql> INSERT cat (

    -> name,
    -> birthday,
    -> skill)
    -> VALUE
    -> ('Персик', '2018-05-17', 'мурчать'),
    -> ('Барсик', '2020-08-10', 'играть'),
    -> ('Мурзик', '2019-07-10', 'спать');

Query OK, 3 rows affected (0,03 sec)

Records: 3  Duplicates: 0  Warnings: 0

mysql> INSERT dog ( name, birthday, skill) VALUE ('Джесси', '2017-02-10', 'дать лапу'), ('Барбос', '2019-04-10', 'голос'
), ('Рик', '2021-08-10', 'апорт');
Query OK, 3 rows affected (0,01 sec)
Records: 3  Duplicates: 0  Warnings: 0

mysql> INSERT hamstel ( name, birthday, skill) VALUE ('Хома', '2021-03-21', 'кушать'), ('Рыжик', '2022-04-10', 'крутить колесо');
Query OK, 2 rows affected (0,02 sec)
Records: 2  Duplicates: 0  Warnings: 0

mysql> INSERT camel ( name, birthday, skill) VALUE ('Тоша', '2020-07-22', 'лежать'), ('Абу', '2016-05-10', 'плюнуть');
Query OK, 2 rows affected (0,01 sec)
Records: 2  Duplicates: 0  Warnings: 0

mysql> INSERT horses ( name, birthday, skill) VALUE ('Иа', '2021-11-20', 'идти'), ('Бася', '2016-07-18', 'кушать');
Query OK, 2 rows affected (0,01 sec)
Records: 2  Duplicates: 0  Warnings: 0

mysql> INSERT donkey ( name, birthday, skill) VALUE ('Чуп', '2020-09-20', 'кушать'), ('Вудди', '2022-02-18', 'спать');
Query OK, 2 rows affected (0,02 sec)
Records: 2  Duplicates: 0  Warnings: 0

mysql> SELECT * FROM dog;


| iddog | name         | birthday            | skill             |
|-------|--------------|---------------------|-------------------|
|     1 | Джесси       | 2017-02-10 00:00:00 | дать лапу         |
|     2 | Барбос       | 2019-04-10 00:00:00 | голос             |
|     3 | Рик          | 2021-08-10 00:00:00 | апорт             |


10. Удалив из таблицы верблюдов, т.к. верблюдов решили перевезти в другой
питомник на зимовку. Объединить таблицы лошади, и ослы в одну таблицу.

## выполнение:

mysql> DELETE FROM camel;

mysql> CREATE TABLE Pack_Animal (

    -> idanimal INT PRIMARY KEY NOT NULL AUTO_INCREMENT)
    -> SELECT
    -> name,
    -> birthday,
    -> skill,
    -> 'horses' as animal_type
    -> FROM
    -> horses;
Query OK, 2 rows affected (0,03 sec)
Records: 2  Duplicates: 0  Warnings: 0

mysql> SELECT * FROM Pack_Animal;


| idanimal | name     | birthday            | skill        | animal_type |
|----------|----------|---------------------|--------------|-------------|
|        1 | Иа       | 2021-11-20 00:00:00 | идти         | horses      |
|        2 | Бася     | 2016-07-18 00:00:00 | кушать       | horses      |

2 rows in set (0,00 sec)

mysql> INSERT INTO Pack_Animal (

    -> name,
    -> birthday,
    -> skill,
    -> animal_type)
    -> SELECT
    -> name,
    -> birthday,
    -> skill,
    -> 'donkey' as animal_type
    -> FROM
    -> donkey;
Query OK, 2 rows affected (0,00 sec)
Records: 2  Duplicates: 0  Warnings: 0

mysql> SELECT * FROM Pack_Animal;

| idanimal | name       | birthday            | skill        | animal_type |
|----------|------------|---------------------|--------------|-------------|
|        1 | Иа         | 2021-11-20 00:00:00 | идти         | horses      |
|        2 | Бася       | 2016-07-18 00:00:00 | кушать       | horses      |
|        4 | Чуп        | 2020-09-20 00:00:00 | кушать       | donkey      |
|        5 | Вудди      | 2022-02-18 00:00:00 | спать        | donkey      |


4 rows in set (0,00 sec)


11. Создать новую таблицу “молодые животные” в которую попадут все
животные старше 1 года, но младше 3 лет и в отдельном столбце с точностью
до месяца подсчитать возраст животных в новой таблице.

## выполнение:

mysql> CREATE TABLE young_animals (id_young_animals INT PRIMARY KEY NOT NULL AUTO_INCREMENT)

    -> SELECT name, birthday, skill, animal_type,
    -> (TIMESTAMPDIFF(MONTH, birthday, CURDATE())) as age
    -> FROM
    -> (SELECT * FROM Pack_Animal UNION SELECT * FROM cat UNION SELECT * FROM dog UNION SELECT * FROM hamstel) s
    -> WHERE birthday BETWEEN CURDATE() - INTERVAL 3 YEAR
    -> AND CURDATE() - INTERVAL 1 YEAR;

Query OK, 6 rows affected (0,04 sec)
Records: 6  Duplicates: 0  Warnings: 0


mysql> SELECT * FROM young_animals;


| id_young_animals | name         | birthday            | skill        | animal_type | age  |
|------------------|--------------|---------------------|--------------|-------------|------|
|                1 | Иа           | 2021-11-20 00:00:00 | идти         | horses      |   15 |
|                2 | Чуп          | 2020-09-20 00:00:00 | кушать       | donkey      |   29 |
|                3 | Вудди        | 2022-02-18 00:00:00 | спать        | donkey      |   12 |
|                4 | Барсик       | 2020-08-10 00:00:00 | играть       | cat         |   30 |
|                5 | Рик          | 2021-08-10 00:00:00 | апорт        | dog         |   18 |
|                6 | Хома         | 2021-03-21 00:00:00 | кушать       | hamstel     |   23 |


6 rows in set (0,00 sec)

12. Объединить все таблицы в одну, при этом сохраняя поля, указывающие на
прошлую принадлежность к старым таблицам.

<<<<<<< HEAD
## выполнение:

mysql> CREATE TABLE All_Animals (id_all_animals INT PRIMARY KEY NOT NULL AUTO_INCREMENT)

    -> SELECT name, birthday, skill, animal_type
    -> FROM
    -> (SELECT * FROM Pack_Animal UNION
    -> SELECT * FROM cat UNION
    -> SELECT * FROM dog UNION
    -> SELECT * FROM hamstel) s;

Query OK, 12 rows affected (0,06 sec)
Records: 12  Duplicates: 0  Warnings: 0

mysql> SELECT * FROM All_Animals;

| id_all_animals | name         | birthday            | skill                       | animal_type |
|----------------|--------------|---------------------|-----------------------------|-------------|
|              1 | Иа           | 2021-11-20 00:00:00 | идти                        | horses      |
|              2 | Бася         | 2016-07-18 00:00:00 | кушать                      | horses      |
|              3 | Чуп          | 2020-09-20 00:00:00 | кушать                      | donkey      |
|              4 | Вудди        | 2022-02-18 00:00:00 | спать                       | donkey      |
|              5 | Персик       | 2018-05-17 00:00:00 | мурчать                     | cat         |
|              6 | Барсик       | 2020-08-10 00:00:00 | играть                      | cat         |
|              7 | Мурзик       | 2019-07-10 00:00:00 | спать                       | cat         |
|              8 | Джесси       | 2017-02-10 00:00:00 | дать лапу                   | dog         |
|              9 | Барбос       | 2019-04-10 00:00:00 | голос                       | dog         |
|             10 | Рик          | 2021-08-10 00:00:00 | апорт                       | dog         |
|             11 | Хома         | 2021-03-21 00:00:00 | кушать                      | hamstel     |
|             12 | Рыжик        | 2022-04-10 00:00:00 | крутить колесо              | hamstel     |

12 rows in set (0,00 sec)
=======
>>>>>>> 2c4c522562f56819293b13fd7e8ac17921d6d69a
