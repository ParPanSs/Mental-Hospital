INCLUDE globals.ink

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
    * [Погладить]
        Вы гладите собаку. Она довольно машет хвостом.
        -> DONE
    * [Пнуть]
        Вы пнули собаку. Она обиженно скулит. У вас совести нет.
        ~ dogWasKicked = true
        -> DONE
        
-> END

= EN
This is a dog. It seems to be happy.
    * [Pet]
        You are petting the dog. It's waving it's tale happily.
        -> DONE
    * [Kick]
        You kicked the dog. It's whining resentfully. Do you have a conscience?
        ~ dogWasKicked = true
        -> DONE
-> END

= CS
Tohle je pes. Vypádá šťastné.
    *[Pohladit]
        Vý hladite psa. Pes spokojené vrtí chvostem.
        -> DONE
    *[Kopnout]
        Kopnuli jste psa. Kňučí uraženě. Nemáte svědomí.
        ~ dogWasKicked = true
        -> DONE
-> END