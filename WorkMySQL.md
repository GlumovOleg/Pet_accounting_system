## ������ � ������������ MySQL

7. � ������������ MySQL ����������� ������� ���� ������ �������
���������.

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

8. ������� ������� � ��������� �� ��������� � ��.

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

9. ��������� �������������� ������� �������(��������), ���������
������� ��� ��������� � ������ ��������.

mysql> INSERT cat (
    -> name,
    -> birthday,
    -> skill)
    -> VALUE
    -> ('������', '2018-05-17', '�������'),
    -> ('������', '2020-08-10', '������'),
    -> ('������', '2019-07-10', '�����');
Query OK, 3 rows affected (0,03 sec)
Records: 3  Duplicates: 0  Warnings: 0

mysql> INSERT dog ( name, birthday, skill) VALUE ('������', '2017-02-10', '���� ����'), ('������', '2019-04-10', '�����'
), ('���', '2021-08-10', '�����');
Query OK, 3 rows affected (0,01 sec)
Records: 3  Duplicates: 0  Warnings: 0

mysql> INSERT hamstel ( name, birthday, skill) VALUE ('����', '2021-03-21', '������'), ('�����', '2022-04-10', '�������
������');
Query OK, 2 rows affected (0,02 sec)
Records: 2  Duplicates: 0  Warnings: 0

mysql> INSERT camel ( name, birthday, skill) VALUE ('����', '2020-07-22', '������'), ('���', '2016-05-10', '�������');
Query OK, 2 rows affected (0,01 sec)
Records: 2  Duplicates: 0  Warnings: 0

mysql> INSERT horses ( name, birthday, skill) VALUE ('��', '2021-11-20', '����'), ('����', '2016-07-18', '������');
Query OK, 2 rows affected (0,01 sec)
Records: 2  Duplicates: 0  Warnings: 0

mysql> INSERT donkey ( name, birthday, skill) VALUE ('���', '2020-09-20', '������'), ('�����', '2022-02-18', '�����');
Query OK, 2 rows affected (0,02 sec)
Records: 2  Duplicates: 0  Warnings: 0

mysql> SELECT * FROM dog;
+-------+--------------+---------------------+-------------------+
| iddog | name         | birthday            | skill             |
+-------+--------------+---------------------+-------------------+
|     1 | ������       | 2017-02-10 00:00:00 | ���� ����         |
|     2 | ������       | 2019-04-10 00:00:00 | �����             |
|     3 | ���          | 2021-08-10 00:00:00 | �����             |
+-------+--------------+---------------------+-------------------+

10. ������ �� ������� ���������, �.�. ��������� ������ ��������� � ������
�������� �� �������. ���������� ������� ������, � ���� � ���� �������.

11. ������� ����� ������� �������� �������� � ������� ������� ���
�������� ������ 1 ����, �� ������ 3 ��� � � ��������� ������� � ���������
�� ������ ���������� ������� �������� � ����� �������.

12. ���������� ��� ������� � ����, ��� ���� �������� ����, ����������� ��
������� �������������� � ������ ��������.