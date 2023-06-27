INCLUDE ../globals.ink

{
    - currentLanguage == "ru": 
       -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

===RU===
Давно не виделись, Ян, чувствуешь ли ты себя лучше? #portrait:Psychoterapeut
*[Да]#portrait:default
    Думаю, да.
    ->TodayConsultation
*[Нет]
    Совсем нет.#portrait:default
    ->TodayConsultation
*[Не знаю]
    Не знаю.#portrait:default
    ->TodayConsultation


===TodayConsultation===
С чем ты сегодня пришел? Что тебя беспокоит? #portrait:Psychoterapeut
*[Не помню]
    Я не помню последнюю неделю.#portrait:default
    Не помнишь, или не хочешь помнить? #portrait:Psychoterapeut
        **[Не помню]
            Не помню.
            Не кажется ли тебе странным, что ты не помнишь?#portrait:Psychoterapeut
            Чем ты занимался, что твоя психика решила скрыть это в твоих воспоминаниях? 
            Чем-то неправильным? Травмирующим?
                ***[Нет]
                    Ничего такого не было... Наверное.#portrait:default
                ->DesireOfPower
    
                ***[Не помню]
                    Я не помню.#portrait:default
                    Подумай об этом. Хочешь ее что то обсудить? #portrait:Psychoterapeut
                ->DesireOfPower
        **[Не хочу]
            Я не хочу помнить.#portrait:default
            Желание - сильная вещь...#portrait:Psychoterapeut
            -> DesireOfPower
*Проблем нет.#portrait:default
    Так не бывает.
    ->DesireOfPower
*Подскажите мне.#portrait:default
    ->DesireOfPower

===DesireOfPower===
Например, желание власти и доминирования в семейном бюджете и то, как ты не хотел выпускать крысу из мышеловки, есть ли какая то связь?#portrait:Psychoterapeut
*[Страх]
    Я ее боялся.#portrait:default
*[Доминация]
    Я не хочу доминировать.#portrait:default
*[Не помню]
    Я такого не помню.#portrait:default
- ->KindOfFear

===KindOfFear===
Боялся, что она убежить и ты не сможешь контролировать ее?#portrait:Psychoterapeut
{
    -pillsWasTaken == false: 
        ~blockChoice(0)
}

*[Контроль]
    Она должна делать то, что я хочу.#portrait:default
    Очень хорошо.#portrait:Psychoterapeut
    ->Ending
*[Страх]
    Она меня укусит.#portrait:default
*[Безразличие]
    Зачем ей убегать?#portrait:default

- То есть сделает так, как ты не хочешь?#portrait:Psychoterapeut
*Да.#portrait:default
*Нет.#portrait:default

- То есть ты хочешь держать власть над ее жизнью, контролировать ее существование.#portrait:Psychoterapeut
    ->Ending

===Ending===
Хорошо, Ян, думаю на сегодня стоит остановиться. Не забывай пить таблетки, это очень важно для тебя.#portrait:Psychoterapeut

Хочу ли я принимать таблетки? #portrait:default
*[Выпить]
    ~ pillsWasTaken = true
    Горькие.
*[Не пить]
    Не думаю, что они мне помогут.

-   ~finishDay()
-> END

===EN===
It's me.
-> END

===CS===
To jsem.
-> END