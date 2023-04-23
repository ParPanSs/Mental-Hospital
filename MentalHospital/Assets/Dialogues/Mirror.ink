INCLUDE globals.ink
//EXTERNAL language(currentLang)

~ currentLanguage = language("en")
{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

= RU
Это вы. Очень красивый и солидный мужчина, прекрасный преподаватель и человек.
-> END

= EN
It's you. Beautiful and solid man, wonderful teacher and human.
-> END

= CS
Tohle jste vý. Krasný a solidní můž, úžasný učitel a člověk.
-> END