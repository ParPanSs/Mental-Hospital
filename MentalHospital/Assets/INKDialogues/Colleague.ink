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
Вы слышали, сегодня найдена еще одна жертва! #portrait:Colleague
Опять? Это уже становится опасно, какая это уже по счету? Шестая? #portrait: SecondColleague
Кажется да, или даже седьмая, что-то этот маньяк-фермер совсем не щадит. #portrait:Colleague
Кстати, наш новый коллега уж слишком подозрительный, отстраненный какой то, мутный тип, не подозрительно ли? #portrait: SecondColleague
Как его перевели, сразу эти случаи и начались, я вам говорю...
Ой, ну так вообще на каждого наговаривать можно. #portrait:Colleague
~offCollider()

-> END

= EN
Colleague is busy, do not disturb him. #portrait:Colleague
-> END

= CS
Kolega má práci. Nerušít, prosím. #portrait:Colleague
-> END