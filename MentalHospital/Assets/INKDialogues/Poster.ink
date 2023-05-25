INCLUDE globals.ink

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

== RU
Распродажа. Вероятно, это хорошая вещь для тех, у кого мало денег.
    *[Сорвать]
        ~pickUpItem()
        Не думаю, что здесь это кому-то нужно.
    ->DONE
    *[Не трогать]
        Вдруг кому-то пригодится.
    ->DONE
-> END

== EN
The bowl is full.
-> END

== CS
Mísa je plná.
-> END