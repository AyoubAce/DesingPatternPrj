

using UnityEngine;
using System.Collections;



    public class MementoP : MonoBehaviour
    {
        void Start()
        {
            SalesProspect s = new SalesProspect();
            s.Name = "Bruce";
            s.Phone = "(412) 256-6666";
            s.Budget = 25000.0;

            // Store internal state
            ProspectMemory m = new ProspectMemory();
            m.Memento = s.SaveMemento();

            // Continue changing originator
            s.Name = "Oliver";
            s.Phone = "(310) 209-8888";
            s.Budget = 1000000.0;

            // Restore saved state
            s.RestoreMemento(m.Memento);

        }
    }

   
    // Originator class

    class SalesProspect
    {
        private string _name;
        private string _phone;
        private double _budget;

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Debug.Log("Name:  " + _name);
            }
        }

        // Gets or sets phone
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                Debug.Log("Phone: " + _phone);
            }
        }

        // Gets or sets budget
        public double Budget
        {
            get { return _budget; }
            set
            {
                _budget = value;
                Debug.Log("Budget: " + _budget);
            }
        }

        // Stores memento
        public Memento SaveMemento()
        {
            Debug.Log("\nSaving state --\n");
            return new Memento(_name, _phone, _budget);
        }

        // Restores memento
        public void RestoreMemento(Memento memento)
        {
            Debug.Log("\nRestoring state --\n");
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }

  
    // Memento class
    
    class Memento
    {
        private string _name;
        private string _phone;
        private double _budget;

        // Constructor
        public Memento(string name, string phone, double budget)
        {
            this._name = name;
            this._phone = phone;
            this._budget = budget;
        }

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or set phone
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        // Gets or sets budget
        public double Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }
    }

 
    //Caretaker class
   
    class ProspectMemory
    {
        private Memento _memento;

        // Property
        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    
}