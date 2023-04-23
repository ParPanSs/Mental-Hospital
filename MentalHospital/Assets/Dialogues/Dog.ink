INCLUDE globals.ink
EXTERNAL language(currentLang)

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
Это собака. Кажется, она довольна жизнью.

...
    * [Погладить]
        Вы гладите собаку. Она довольно машет хвостом.
        -> DONE
    * [Пнуть]
        Вы пнули собаку. Она обиженно скулит. У вас совести нет.
        -> DONE
        
-> END

= EN

This is a dog. It seems to be happy.

...
    * [To pet]
        You are petting the dog. It's waving it's tale happily.
        -> DONE
    * [To kick]
        You kicked the dog. It's whining resentfully. Do you have a conscience?
        -> DONE
-> END

= CS
Tohle je pes. Vypádá šťastné.

...
    *[Pohladit]
        Vý hladite psa. Pes spokojené vrtí chvostem.
        -> DONE
    *[Kopnout]
        Koupnuli jste psa. Pes kňučí uraženě. Máte svědomí?
        -> DONE
-> END
        