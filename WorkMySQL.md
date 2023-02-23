Работа с репозиторием MySQL

7. В подключенном MySQL репозитории создать базу данных “Друзья
человека”.

mysql> CREATE DATABASE Human_Friends;
Query OK, 1 row affected (0,03 sec)

mysql> SHOW DATABASES;
+--------------------+
| Database           |
+--------------------+
| Human_Friends      |
| information_schema |
| mysql              |
| performance_schema |
| sys                |
+--------------------+
5 rows in set (0,05 sec)

8. Создать таблицы с иерархией из диаграммы в БД.

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

+-------------------------+
| Tables_in_Human_Friends |
+-------------------------+
| camel                   |
| cat                     |
| dog                     |
| donkey                  |
| hamstel                 |
| horses                  |
+-------------------------+

6 rows in set (0,00 sec)

9. Заполнить низкоуровневые таблицы именами(животных), командами
которые они выполняют и датами рождения.

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
+-------+--------------+---------------------+-------------------+
| iddog | name         | birthday            | skill             |
+-------+--------------+---------------------+-------------------+
|     1 | Äæåññè       | 2017-02-10 00:00:00 | äàòü ëàïó         |
|     2 | Áàðáîñ       | 2019-04-10 00:00:00 | ãîëîñ             |
|     3 | Ðèê          | 2021-08-10 00:00:00 | àïîðò             |
+-------+--------------+---------------------+-------------------+

10. Удалив из таблицы верблюдов, т.к. верблюдов решили перевезти в другой питомник на зимовку. Объединить таблицы лошади, и ослы в одну таблицу.

11. Создать новую таблицу “молодые животные” в которую попадут все животные старше 1 года, но младше 3 лет и в отдельном столбце с точностью до месяца подсчитать возраст животных в новой таблице.

12. Объединить все таблицы в одну, при этом сохраняя поля, указывающие на прошлую принадлежность к старым таблицам.
