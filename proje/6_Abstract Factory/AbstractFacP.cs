
using UnityEngine;
using System.Collections;


   public class  AbstractFacP : MonoBehaviour
    {
        void Start()
        {
            // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
        }
    }



    //AbstractFactory abstract class

    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

  
    //ConcreteFactory1 class
    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    //
    //ConcreteFactory2 class

    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    //AbstractProductA abstract class
    abstract class Herbivore
    {
    }

  
    //AbstractProductB abstract class

    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }


    //ProductA1 class
    class Wildebeest : Herbivore
    {
    }


    // ProductB1 class
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Debug.Log(this.GetType().Name +" eats " + h.GetType().Name);
        }
    }

   
    //ProductA2 class
 
    class Bison : Herbivore
    {
    }

   
    //ProductB2 class
    
    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Debug.Log(this.GetType().Name +" eats " + h.GetType().Name);
        }
    }

    
    //Client class 
   
    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        // Constructor
        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    
}