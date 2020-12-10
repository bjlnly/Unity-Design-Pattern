//-------------------------------------------------------------------------------------
//	DecoratorPatternExample1.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstrates the Decorator pattern in which 'borrowable' functionality is added to existing library items(books and videos).
//这段真实世界的代码演示了Decorator模式，其中 "可借 "功能被添加到现有的图书馆项目（书籍和视频）中。

namespace DecoratorPatternExample1
{

    public class DecoratorPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            // Create book
            // 创建书籍并展示
            Book book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            // Create video
            // 创建视频并展示
            Video video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Debug.Log("\nMaking video borrowable:");

            // 让视频可借 并且借出去
            Borrowable borrowvideo = new Borrowable(video);
            borrowvideo.BorrowItem("Customer #1");
            borrowvideo.BorrowItem("Customer #2");

            // 展示借走资料的人的信息
            borrowvideo.Display();
        }
    }

    /// <summary>
    /// The 'Component' abstract class 被装饰基类 -- 图书馆 
    /// </summary>
    abstract class LibraryItem
    {
        private int _numCopies;

        // Property
        public int NumCopies
        {
            get { return _numCopies; }
            set { _numCopies = value; }
        }

        public abstract void Display();
    }

    /// <summary>
    /// The 'ConcreteComponent' class 具体的被装饰类 -- 书籍
    /// </summary>
    class Book : LibraryItem
    {
        // 有自己的特殊属性
        private string _author;
        private string _title;

        // Constructor
        public Book(string author, string title, int numCopies)
        {
            this._author = author;
            this._title = title;
            this.NumCopies = numCopies;
        }

        // 但是要实现基类的接口
        public override void Display()
        {
            Debug.Log("\nBook ------ ");
            Debug.Log(" Author: "+ _author);
            Debug.Log(" Title: "+ _title);
            Debug.Log(" # Copies: "+ NumCopies);
        }
    }

    /// <summary>
    /// The 'ConcreteComponent' class 具体的被装饰类 -- 影片
    /// </summary>
    class Video : LibraryItem
    {
        private string _director;
        private string _title;
        private int _playTime;

        // Constructor
        public Video(string director, string title,
          int numCopies, int playTime)
        {
            this._director = director;
            this._title = title;
            this.NumCopies = numCopies;
            this._playTime = playTime;
        }

        public override void Display()
        {
            Debug.Log("\nVideo ----- ");
            Debug.Log(" Director: "+ _director);
            Debug.Log(" Title: "+ _title);
            Debug.Log(" # Copies: "+ NumCopies);
            Debug.Log(" Playtime: "+ _playTime+ "\n");
        }
    }

    /// <summary>
    /// The 'Decorator' abstract class  装饰基类,继承自图书馆基类
    /// </summary>
    abstract class Decorator : LibraryItem
    {
        // 有一个基类属性
        protected LibraryItem libraryItem;

        // Constructor
        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        // 实现了基类方法
        public override void Display()
        {
            libraryItem.Display();
        }
    }

    /// <summary>
    /// The 'ConcreteDecorator' class 具体的装饰类 -- 可借
    /// </summary>
    class Borrowable : Decorator
    {
        protected List<string> borrowers = new List<string>();

        // Constructor
        public Borrowable(LibraryItem libraryItem)
          : base(libraryItem)
        {
        }

        // 实现了借 还
        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.NumCopies++;
        }

        // 展示所有借资料的人名
        public override void Display()
        {
            base.Display();

            foreach (string borrower in borrowers)
            {
                Debug.Log(" borrower: " + borrower);
            }
        }
    }
}
