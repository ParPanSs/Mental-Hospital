INCLUDE globals.ink

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

===RU===
Вы пришли на работу. Сегодня вам нужно выбирать текст для поздравительных открыток. #portrait:PC

Счастливого дня рождения! Пусть солнце всегда сияет ярко в твоей жизни, а успех и радость сопровождают тебя на каждом шагу. Желаю...
    * [Любви]
        Вы выбрали первый вариант.
        -> SecondChoice
    * [Улыбок]
        Вы выбрали второй вариант.
        -> SecondChoice
    * [Неприятностей]
        Вы выбрали третий вариант.
        -> SecondChoice
    = SecondChoice
    Поздравляю с днем свадьбы! Пусть ваш союз будет крепким и прочным, наполненным любовью и взаимопониманием. Желаю вам...
    *[Романтики]
        Вы выбрали первый вариант.
        -> ThirdChoice
    *[Семейного благополучия]
        Вы выбрали второй вариант.
        -> ThirdChoice
    *[Ссор и недоверия]
        Вы выбрали третий вариант.
        -> ThirdChoice
    = ThirdChoice
    ~offCollider()
    С наступающим Новым годом! Пусть в новом году тебя окружают только положительные эмоции, здоровье и благополучие. Желаю...
    ~ workWasDone = true
    *[Успехов]
        Вы выбрали первый вариант. Сегодня работы больше нет.
        -> END
    *[Веселья]
        Вы выбрали второй вариант. Сегодня работы больше нет.
        -> END
    *[Трудностей]
        Вы выбрали третий вариант. Сегодня работы больше нет.
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