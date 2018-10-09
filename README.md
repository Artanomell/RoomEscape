# RoomEscape
## Требования к проекту
### 1 Введение
Room Escape - 2D игра в жанре Puzzle-Platformer на ОС Windows, геймплей которой представляет собой решение головоломок и поиска выхода из комнаты, где каждая комната - отдельный уровень. Головоломки решаются путём поиска и взаимодействия игрового персонажа с предметами, которые спрятаны по уровню. В конечном итоге в каждой комнате игрок должен найти ключ, с помощью которого сможет открыть дверь в следующую комнату.

### 2 Требования пользователя
#### 2.1 Программные интерфейсы
* Платформа .NET, C# для разработки логики проекта
* Unity Engine

#### 2.2 Интерфейс пользователя
При запуске игрок видит главное меню с кнопками Start, Stats, Exit. Данные кнопки расписаны в разделе “функциональные требования”. При запуске игрок загружается на уровень, на котором в последний раз остановился. Если сохранения нет, то игрок появляется на первом уровне. Управление указано в разделе “функциональные требования”.

Мокапы:
* Меню

![Menu](https://cdn.discordapp.com/attachments/428973249502642208/499311704082219019/unknown.png)

* Геймплей

![Gameplay](https://cdn.discordapp.com/attachments/178558940315910145/499317142873833472/unknown.png)

#### 2.3 Характеристики пользователей
Целевая аудитория:
* 13-50 лет;
* Любители жанра Platformer и Puzzle-Platformer

#### 2.4 Предположения и зависимости

### 3 Системные требования
#### 3.1 Функциональные требования
Пользователю доступны следующие функции:
* Начало или загрузка игры (кнопка Start в главном меню)
* Просмотр общей статистики (кнопка Stats в главном меню)
* Выход из игры (кнопка Exit в главном меню)

Управление:
* Передвижение персонажа (стрелка-влево, стрелка-вправо)
* Прыжок (X)
* Подобрать/бросить предмет (Z)
* Войти в дверь (стрелка-вверх)
#### 3.2 Нефункциональные требования
##### 3.2.1 АТРИБУТЫ КАЧЕСТВА
Игра должна иметь:
* Частоту кадров не ниже 60 на персональном компьютере, соответствующем системным требованиям.
##### 3.2.2 Рекомендуемые системные требования
ОС: Windows 10

Оперативная память: 4 GB ОЗУ

DirectX: Версии 10 и выше

Процессор: Intel Core i5-7500

Видеокарта: Nvidia GeForce GTX 460
