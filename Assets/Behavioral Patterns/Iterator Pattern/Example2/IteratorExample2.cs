//-------------------------------------------------------------------------------------
//	IteratorExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/* Iterator provides uniform way to access different collections of objects
 * If you get an Array, ArrayList, Hashtable of objects, you pop out an iterator for each and treat them the same
 * 
 * This provides a uniform way to cycle through different collections
 * 
 * You can also write polymorphic code because you can refer to each collection of objects
 * because they'll implement the same interface
 * */
/* 迭代器为访问不同的对象集合提供了统一的方法。
 * 如果你得到一个Array, ArrayList, Hashtable的对象，你会为每个对象弹出一个迭代器，并对它们进行同样的处理。
 * 
 * 这提供了一种统一的方式来循环浏览不同的集合。
 * 
 * 你也可以写多态代码，因为你可以引用每一个对象的集合
 * 因为它们将实现相同的接口
 * */

public class IteratorExample2 : MonoBehaviour
{
	void Start ( )
	{
        // creating the collections and adding some songs:
        // 创建合集并加入一些歌曲
        SongsOfThe70s song70s = new SongsOfThe70s();
        song70s.AddSong("song title", "song artist", 1974);
        song70s.AddSong("song title2", "song artist2", 1978);

        SongsOfThe80s song80s = new SongsOfThe80s();
        song80s.AddSong("song title 80s", "song artist 80s", 1985);
        song80s.AddSong("song title2 80s", "song artist2 80s", 1989);

        // because of the iterator pattern we can loop through both types
        // of collections the same simple way and don't have to bother
        // with what type of collection the object stores:
        // 由于迭代器模式，我们可以同时在两种类型中循环。
        // 有同样简单的方式，而不必费心去用什么类型的集合存储对象。
        
        IEnumerator songsOfThe70sIterator = song70s.GetIterator();
        while (songsOfThe70sIterator.MoveNext())
        {
            SongInfo info = (SongInfo)songsOfThe70sIterator.Current;
            Debug.Log("Song 70s: " + info.ToStringEx());
        }

        IEnumerator songsOfThe80sIterator = song80s.GetIterator();
        while (songsOfThe80sIterator.MoveNext())
        {
            SongInfo info = (SongInfo)songsOfThe80sIterator.Current;
            Debug.Log("Song 80s: " + info.ToStringEx());
        }
    }



    // just a sample object to hold some arbitrary information for demonstration
    // 仅仅是一个样本对象，用来保存一些任意的信息，以便于演示。
    public class SongInfo
    {
        public string songName { get; protected set; }

        public string bandName { get; protected set; }

        public int yearReleased { get; protected set; }

        public SongInfo(string songName, string bandName, int yearReleased)
        {
            this.songName = songName;
            this.bandName = bandName;
            this.yearReleased = yearReleased;
        }

        public string ToStringEx()
        {
            return this.songName + " - " + this.bandName + " : " + this.yearReleased.ToString();
        }
    }



    // Iterator Interface
    // 遍历接口 获取遍历对象
    public interface SongIterator
    {
        IEnumerator GetIterator();
    }



    // These two classes implement the iterator
    // 实现遍历器
    public class SongsOfThe70s : SongIterator
    {
        // here it is a list
        protected List<SongInfo> bestSongs;

        public SongsOfThe70s()
        {
            bestSongs = new List<SongInfo>();
        }

        public void AddSong(string name, string artist, int year)
        {
            SongInfo song = new SongInfo(name, artist, year);
            bestSongs.Add(song);
        }

        //about yield return :http://www.jb51.net/article/54810.htm
        // heart
        // 单步获取信息 用yield来转化对象 转为IEnumerator
        public IEnumerator GetIterator()
        {
            foreach (SongInfo song in bestSongs)
                 yield return song;
            yield break;
        }
    }

    public class SongsOfThe80s : SongIterator
    {
        // here we have an array
        protected SongInfo[] bestSongs;

        public SongsOfThe80s()
        {
            bestSongs = new SongInfo[0];
        }

        public void AddSong(string name, string artist, int year)
        {
            SongInfo song = new SongInfo(name, artist, year);
            // just for the sake of easyness of appending something we will convert the array to a list
            List<SongInfo> newSongs = new List<SongInfo>(bestSongs);
            // add a new element
            newSongs.Add(song);
            // and convert it back to an array
            bestSongs = newSongs.ToArray();
        }

        // heart
        public IEnumerator GetIterator()
        {
            foreach (SongInfo song in bestSongs)
                yield return song;
            yield break;
        }
    }



}



