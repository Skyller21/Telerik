## Шаблон Фасада (Façade) ##

### Цел на шаблона ###

Целта на шаблона "Фасада" (Façade) е да предостави опростен интерфейс за взаимодействие със сложна подсистема или множество подсистеми.

![](https://github.com/vesheff/Telerik/blob/master/08.High%20Quality%20Code/16.StructuralPatterns/img/facade.jpg)

### Приложимост ###
При разработката на софтуер, често ни се налага да използваме техники за ограничаване на зависимостите между обектите и намаляване на сложността при взаимодействието между тях.


- Нужда от опростен интерфейс към сложна система – създаването на фасада, даваща достъп на клиентите само до нужната им функционалност скрива от тях сложността на системата.

- 	При наличие на твърде голяма зависимост между клиентите и конкретните имплементации на дадена абстракция – в този случай поставянето на фасада между клиентите и имплементацията премахва директната зависимост между тях. 

### Участници ###

- Клиент (Client) - Това е класът, който се нуждае от взаимодействие с класовете на подсистемата. Има за цел да взаимодейства с интерфейса на фасадата вместо да достъпва класовете на подсистемата. С една фасада може да взаимодейства повече от един клиент

- 	Фасада (Facade) - Предоставя опростен интерфейс към подсистемата. Познава вътрешната структура, класовете и връзките помежду им и знае как да взаимодейства с тях.
- 	Класове на подсистемата (Subsystem classes) – Дават достъп до различните функционалности на подсистемата. Изпълняват заявките изпратени от фасадата. Не зависят от фасадата и не знаят за нейното съществуване

### Приложения ###
Уеб услугите (Web services) предоставят достъп на различни клиенти до сложна система без клиентите да знаят за сложността й и без системата да се интересува какъв клиент ще достъпва услугите, които тя предлага.

### Свързани шаблони ###
"Абстрактна фабрика" (Abstract Factory)

"Сингълтон" (Singleton) 

### Имплементация ###

```c#
    
    public class Chef
    {
        private ITableware bowl;
        private IIngredient[] ingredients;

        public void Cook(params IIngredient[] ingredients)
        {
            this.ingredients = ingredients;
            this.bowl = this.GetBowl();
            this.ProccessIngredients(this.bowl, this.ingredients);
            Console.WriteLine("COOKING TIME...");
        }

        private void ProccessIngredients(ITableware bowlToUse, params IIngredient[] ingredientsToUse)
        {
            foreach (var ingredient in ingredientsToUse)
            {
                this.Peel(ingredient);
                this.Cut(ingredient);
                bowlToUse.Add(ingredient);
            }
        }

        private ITableware GetBowl()
        {
            return new Bowl();
        }


        private void Cut(IIngredient ingredient)
        {
            Console.WriteLine("Cutting {0}", ingredient.GetType().Name);
        }
        
        private void Peel(IIngredient ingredient)
        {
            Console.WriteLine("Peeling {0}", ingredient.GetType().Name);
        }
    }


```

```c#

	public class Program
    {
        public static void Main(string[] args)
        {
            Chef chef = new Chef();
            IIngredient[] list = { new Carrot(), new Potato() };
            chef.Cook(list);
        }
    }
```


