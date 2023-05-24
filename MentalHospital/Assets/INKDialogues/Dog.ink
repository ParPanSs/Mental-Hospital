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
Это собака. Кажется, она довольна жизнью. #portrait:Dog
    * [Погладить]
        Вы гладите собаку. Она довольно машет хвостом. #portrait:Dog
        -> DONE
    * [Пнуть]
        Вы пнули собаку. Она обиженно скулит. У вас совести нет. #portrait:Dog
        ~ dogWasKicked = true
        -> DONE
        
-> END

= EN
This is a dog. It seems to be happy. #portrait:dog
    * [Pet]
        You are petting the dog. It's waving it's tale happily. #portrait:Dog
        -> DONE
    * [Kick]
        You kicked the dog. It's whining resentfully. Do you have a conscience? #portrait:Dog
        ~ dogWasKicked = true
        -> DONE
-> END

= CS
Tohle je pes. Vypádá šťastné. #portrait:dog
    * [Pohladit]
        Vý hladite psa. Pes spokojené vrtí chvostem. #portrait:Dog
        -> DONE
    * [Kopnout]
        Kopnuli jste psa. Kňučí uraženě. Nemáte svědomí. #portrait:Dog
        ~ dogWasKicked = true
        -> DONE
-> END