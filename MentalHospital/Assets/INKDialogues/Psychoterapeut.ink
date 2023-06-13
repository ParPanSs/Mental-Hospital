INCLUDE globals.ink

{
    - currentLanguage == "ru": 
        -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

===RU==
Как твое самочувствие, Ян? #portrait:Psychoterapeut
* Лучше. #portrait:default
-> Part2
* Так же. #portrait:default
->Part2
* Не знаю. #portrait:default
->Part2

=Part2
Что произошло за эту неделю? Были ли какие-то особые случаи? #portrait:Psychoterapeut
    * [Рассказать]
        Я испортил рисунок девочки на асфальте, она сказала, что не простит меня. #portrait:default
        -> Part3
    * [Молчать]
        ... #portrait:default
        ->Part5
=Part3
Какие чувства у тебя это вызвало? #portrait:Psychoterapeut
            * Грусть. #portrait:default
            -> Part4
            * Злость. #portrait:default
            -> Part4
            * Страх. #portrait:default
            -> Part4
=Part4
На что это похоже? Может ты испытывал что-то подобное уже до этого? С отцом? #portrait:Psychoterapeut
            * Похоже. #portrait:default
            -> Part5
            * Нет. #portrait:default
            -> Part5
=Part5
Что-ж, можем тогда продолжить с того, на чем закончили в прошлый раз. #portrait:Psychoterapeut
->LOST

==LOST==
Потеря близкого это всегда тяжело, а тем более такая трагичная, и люди по-разному выражают свои эмоции, это нормально, если у тебя подобный способ. 
Как часто ты срываешься на незнакомых людях?
    * Часто. #portrait:default
    -> Part6
    * Редко. #portrait:default
    -> Part6
=Part6
Думаешь ли ты, что они виноваты в том, что с тобой случилось? #portrait:Psychoterapeut
    * Нет. #portrait:default
    -> Part7
    * Да. #portrait:default
    -> Part7
=Part7
Ты думаешь, что они должны понести наказание за это? Ответить за случившееся? #portrait:Psychoterapeut
    * Они не виноваты. #portrait:default
    -> Part8
    * Они виноваты в бездействии. #portrait:default
    -> Part8
    * Я не знаю. #portrait:default
    -> Part8
=Part8
Стало ли что-то яснее? Может ты что-то новое открыл в себе? #portrait:Psychoterapeut
    * Да, вроде что-то понимаю. #portrait:default
    -> Ending
    * Больше запутался. #portrait:default
    -> Ending
    * Я не знаю. #portrait:default
    -> Ending
=Ending
Ян, не забывай, пожалуйста, пить каждый день лекарства, которые я тебе назначил, это очень важно для твоего самочувствия. На сегодня мы закончим, у нас всех был тяжелый день. #portrait:Psychoterapeut

Хочу ли я принимать таблетки? #portrait:default
*[Выпить]
    Горькие.
    ~finishDay()
    -> END
*[Не пить]
    Не думаю, что они мне помогут.
    ~finishDay()
    ->END



===EN==
This is psychoterapeut. Dialogue with him is absent, regretfully. #portrait:Psychoterapeut
    *[Finish the day]
        ~ finishDay()
        -> DONE
    *[Leave]
        ... #portrait:default
        -> DONE
->END

===CS===
To je psychoterapeut. Dialog s nim chybí. Je mi lito. #portrait:Psychoterapeut
    *[Ukončit den]
        ~ finishDay()
        -> END
    *[Ujít]
        ... #portrait:default
        -> DONE
-> END