using System;
using System.Collections.Generic;
using UnityEngine;

namespace Structural_Patterns.Filter_Pattern
{
    //我们将创建一个 Person 对象、
    //Criteria 接口和实现了该接口的实体类，来过滤 Person 对象的列表。
    //CriteriaPatternDemo，我们的演示类使用 Criteria 对象，
    //基于各种标准和它们的结合来过滤 Person 对象的列表。
    public class FilterPatternExample: MonoBehaviour
    {
        private void Start()
        {
            // 创建需要过滤的目标列表
            List<Person> persons = new List<Person>();
            persons.Add(new Person("Robert","Male", "Single"));
            persons.Add(new Person("John","Male", "Married"));
            persons.Add(new Person("Laura","Female", "Married"));
            persons.Add(new Person("Diana","Female", "Single"));
            persons.Add(new Person("Mike","Male", "Single"));
            persons.Add(new Person("Bobby","Male", "Single"));
 
            // 创建过滤器
            Criteria male = new CriteriaMale();
            Criteria female = new CriteriaFemale();
            Criteria single = new CriteriaSingle();
            Criteria singleMale = new AndCriteria(single, male);
            Criteria singleOrFemale = new OrCriteria(single, female);
 
            // 过滤器通用接口过滤 并打印结果
            Debug.Log("\nMale: ");
            PrintPersons(male.meetCriteria(persons));
 
            Debug.Log("\nFemales: ");
            PrintPersons(female.meetCriteria(persons));
 
            Debug.Log("\nSingle Males: ");
            PrintPersons(singleMale.meetCriteria(persons));
 
            Debug.Log("\nSingle Or Females: ");
            PrintPersons(singleOrFemale.meetCriteria(persons));
        }
        
        private void PrintPersons(List<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine("Person : [ Name : " + person.getName() 
                                                       +", Gender : " + person.getGender() 
                                                       +", Marital Status : " + person.getMaritalStatus()
                                                       +" ]");
            }
        } 

    }
    
    /// <summary>
    /// Class 我们将要过滤的目标
    /// </summary>
    class Person
    {
        string name;          //名字
        string gender;        //性别
        string maritalStatus; //婚姻状况
 
        public Person(string name, string gender, string maritalStatus)
        {
            this.name = name;
            this.gender = gender;
            this.maritalStatus = maritalStatus;
        }
 
        public string getName()
        {
            return name;
        }
 
        public string getGender()
        {
            return gender;
        }
 
        public string getMaritalStatus()
        {
            return maritalStatus;
        }
    }
    
    /// <summary>
    /// 抽象类  过滤器(标准)基类
    /// </summary>
    interface Criteria
    {
        //过滤器的规则函数
        List<Person> meetCriteria(List<Person> persons);
    }
        
    /// <summary>
    /// 具体规则类  -- 剥离男性
    /// </summary>
    class CriteriaMale : Criteria
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            //过滤出满足性别为‘MALE’的一些人
            List<Person> malePersons = new List<Person>();
            foreach (var person in persons)
            {
                if (person.getGender().Equals("Male"))
                    malePersons.Add(person);
            }
            return malePersons;
        }
    }

    /// <summary>
    /// 具体规则类 -- 剥离女性
    /// </summary>
    class CriteriaFemale : Criteria
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            //过滤出满足性别为‘FEMALE’的一些人
            List<Person> femalPerson = new List<Person>();
            foreach (var person in persons)
            {
                if (person.getGender().Equals("Female"))
                    femalPerson.Add(person);
            }
            return femalPerson;
        }
    }

    /// <summary>
    /// 具体规则类 -- 剥离单身
    /// </summary>
    class CriteriaSingle : Criteria
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            //过滤出单身人群
            List<Person> singlePersons = new List<Person>();
            foreach (var person in persons)
            {
                if (person.getMaritalStatus().Equals("Single"))
                    singlePersons.Add(person);
            }
            return singlePersons;
        }
    }

    /// <summary>
    /// 复合规则类 -- 剥离同时符合两种规则的目标 -- 抽象意义的复合
    /// </summary>
    class AndCriteria : Criteria
    {
        Criteria criteria;
        Criteria otherCriteria;
 
        public AndCriteria(Criteria criteria, Criteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }
        //过滤出同时满足criteria和otherCriteria规则的人
        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaPersons = criteria.meetCriteria(persons);
            return otherCriteria.meetCriteria(firstCriteriaPersons);
        }
    }

    /// <summary>
    /// 同上 -- 只是复合的类型变化
    /// </summary>
    class OrCriteria : Criteria
    {
        Criteria criteria;
        Criteria otherCriteria;
 
        public OrCriteria(Criteria criteria, Criteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }
        //过滤出满足criteria或者otherCriteria过滤规则的人
        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaItems = criteria.meetCriteria(persons);
            List<Person> otherCriteriaItems = otherCriteria.meetCriteria(persons);
            foreach (var person in otherCriteriaItems)
            {
                if (!firstCriteriaItems.Contains(person))
                    firstCriteriaItems.Add(person);
            }
            return firstCriteriaItems;
        }
    }

}