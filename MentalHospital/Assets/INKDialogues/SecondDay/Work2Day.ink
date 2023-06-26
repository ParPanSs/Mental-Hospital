INCLUDE ../globals.ink

EXTERNAL firstCard()
EXTERNAL secondCard()
EXTERNAL thirdCard()
EXTERNAL hideCards()

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

===RU===
Сегодняшние задачи: подбор изображений к текстам поздравительных открыток. #portrait:PC
~firstCard()
Открытка на день рождения:
    * [Медведь]
        Вы выбрали первый вариант.
        ~hideCards()
        -> SecondChoice
    * [Нож]
        Вы выбрали второй вариант.
        ~hideCards()
        -> SecondChoice
    * [Торт]
        Вы выбрали третий вариант.
        ~hideCards()
        -> SecondChoice
    = SecondChoice
    ~secondCard()
    Открытка на день свадьбы:
    *[Подарок]
        Вы выбрали первый вариант.
        ~hideCards()
        -> ThirdChoice
    *[Бутылка]
        Вы выбрали второй вариант.
        ~hideCards()
        -> ThirdChoice
    *[Яблоко]
        Вы выбрали третий вариант.
        ~hideCards()
        -> ThirdChoice
    = ThirdChoice
    ~thirdCard()
    Открытка на новый год:
    
    ~ workWasDone = true
    *[Букет]
        Вы выбрали первый вариант. Сегодня работы больше нет.
        ~hideCards()
        ~offCollider()
        -> END
    *[Цветок]
        Вы выбрали второй вариант. Сегодня работы больше нет.
        ~hideCards()
        ~offCollider()
        -> END
    *[Кольца]
        Вы выбрали третий вариант. Сегодня работы больше нет.
        ~hideCards()
        ~offCollider()
        -> END
-> END

===EN===
You are at work today, and you need to choose a text for gift cards.

Happy birthday! May the sun always shine brightly in your life, and may success and joy accompany you every step of the way. Wishing you...
    * [Love]
        You have chosen first variant.
        -> SecondChoice
    * [Smiles]
        You have chosen second variant.
        -> SecondChoice
    * [Troubles]
        You have chosen third variant.
        -> SecondChoice
    = SecondChoice
    Congratulations on your wedding day! May your union be strong and enduring, filled with love and understanding. Wishing you...
    *[Romance]
        You have chosen first variant.
        -> ThirdChoice
    *[Family well-being]
        You have chosen second variant.
        -> ThirdChoice
    *[Quarrels and mistrust]
        You have chosen third variant.
        -> ThirdChoice
    = ThirdChoice
    Happy New Year! May the coming year bring you only positive emotions, good health, and prosperity. Wishing you...
    ~ workWasDone = true
    *[Success]
        You have chosen first variant. No more work for today.
        -> END
    *[Fun]
        You have chosen second variant. No more work for today.
        -> END
    *[Troubles]
        You have chosen third variant. No more work for today.
        -> END
-> END

===CS===
Jste v práci a dnes potřebujete vybrat text pro přáníčka.

Přeji ti šťastný den narozenin! Ať slunce vždy září jasně ve tvém životě a úspěch a radost tě provázejí na každém kroku. Přeji ti...
    * [Lásku]
        Výbrali jste první variantu.
        -> SecondChoice
    * [Úsměvy]
        Výbrali jste druhou variantu.
        -> SecondChoice
    * [Nepříjemností]
        Výbrali jste třetí variantu.
        -> SecondChoice
    = SecondChoice
    Blahopřeji k tvému svatebnímu dni! Ať je vaše spojení pevné a trvalé, naplněné láskou a porozuměním. Přeji vám...
    *[Romantiku]
        Výbrali jste první variantu.
        -> ThirdChoice
    *[Rodinnou pohodu]
        Výbrali jste druhou variantu.
        -> ThirdChoice
    *[Hádek]
        Výbrali jste třetí variantu.
        -> ThirdChoice
    = ThirdChoice
    S přicházejícím Novým rokem! Ať tě v novém roce obklopují pouze pozitivní emoce, zdraví a blahobyt. Přeji ti...
    ~ workWasDone = true
    *[Úspěch]
        Výbrali jste první variantu. Dnes už není žádná práce.
        -> END
    *[Zábavy]
        Výbrali jste druhou variantu. Dnes už není žádná práce.
        -> END
    *[Obtíží]
        Výbrali jste třetí variantu. Dnes už není žádná práce.
        -> END
-> END