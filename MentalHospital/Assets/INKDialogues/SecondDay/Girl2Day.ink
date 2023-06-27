INCLUDE ../globals.ink
EXTERNAL callBus()

{
    - currentLanguage == "ru": 
        -> RU
    - currentLanguage == "en": 
        -> EN
    - currentLanguage == "cs": 
        -> CS
}

== RU
~offCollider()
О, да это же ты, ломатель моих рисунков, на этот раз ты его не испортишь! #portrait:Girl
{
    - apologizeWasTaken == true:
        ~ blockChoice(1)
    - apologizeWasTaken == false:
        ~ blockChoice(0)
}
...
*Я же извинился.#portrait:default
    Я все равно это помню, ломатель.#portrait:Girl
*...#portrait:default
    Это все еще на твоей совести.#portrait:Girl
- -> Questions

->END

= Questions
...
*Что ты здесь делаешь? #portrait:default
*Ты не маленькая ездить одна? #portrait:default
-->SmallTalk
->END

= SmallTalk
Я жду маму, она ушла и обещала, что скоро вернется обратно. #portrait:Girl
Давно уже сидишь? #portrait:default
Я каждый день сюда прихожу, хочу встретить ее сразу на остановке и подарить рисунок.#portrait:Girl 
Папа говорит, что я обязательно дождусь. Ты тоже так думаешь? #portrait:Girl
*[Нет]#portrait:default
    Не думаю, что она вернется. 
    Обманщик!#portrait:Girl
    ~callBus()
    ->END
*[Да]#portrait:default
    Конечно.
    Я так и знала! #portrait:Girl
    { - apologizeWasTaken == true: 
        Я тоже так думаю. Возьми еще один фломастер, вдруг ты тоже хочешь порисовать для кого-то.
    }
    ~callBus()
->END




== EN
This is a girl. You've stepped on her drawing. #portrait:Girl
-> END

== CS
Tohle je holka. Nastoupil jste na jeji kresleni. #portrait:Girl
-> END