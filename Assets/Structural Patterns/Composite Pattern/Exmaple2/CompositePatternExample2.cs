//-------------------------------------------------------------------------------------
//	CompositePatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CompositePatternExample2
{
    /// <summary>
    /// 这是一个很好的例子  整体和部分之间并不一定会那么一致
    /// 这个时候,抽象他们一致的部分 -- 比如它们都是音乐相关的 -- 可能也是不错的选择
    /// 此时的问题就是,配置整体树的时候, 要分清楚树枝和树干的差异, 避免new的时候传参有误
    /// </summary>
    public class CompositePatternExample2 : MonoBehaviour
    {
        void Start()
        {
            // 工业音乐 -- 是一个组
            SongComponent industrialMusic = new SongGroup("Industrial Music", "Industrial music is a genre of experimental music that draws on transgressive and provocative themes. The term was coined in the mid-1970s with the founding of Industrial Records by Genesis P-Orridge of Throbbing Gristle and Monte Cazazza; on Throbbing Gristle's debut album The Second Annual Report, they coined the slogan \"industrial music for industrial people\".");
            // 重金属音乐 -- 是一个组
            SongComponent heavyMetalMusic = new SongGroup("Heavy Metal Music", "Heavy metal is a genre of rock music[1] that developed in the late 1960s and early 1970s, largely in the United States and the United Kingdom.[2] With roots in blues rock and psychedelic rock,[3] the bands that created heavy metal developed a thick, massive sound, characterized by highly amplified distortion, extended guitar solos, emphatic beats, and overall loudness. Heavy metal lyrics and performance styles are often associated with masculinity, aggression, and machismo.[3]");
            // 杜比音乐 -- 是一个组
            SongComponent dubstepMusic = new SongGroup("Dubstep Music", "Dubstep /ˈdʌbstɛp/ is a genre of electronic dance music that originated in South London, England. It emerged in the late 1990s as a development within a lineage of related styles such as 2-step garage, broken beat, drum and bass, jungle, dub and reggae.[2] In the UK the origins of the genre can be traced back to the growth of the Jamaican sound system party scene in the early 1980s.[2][3] The music generally features syncopated drum and percussion patterns with bass lines that contain prominent sub bass frequencies.");

            // 每一个音乐 -- 是一个根
            SongComponent everySong = new SongGroup("Song List", "Every Song available");
            everySong.Add(industrialMusic);
            industrialMusic.Add(new Song("Head Like a Hole", "NIN", 1990));
            industrialMusic.Add(new Song("headhunter", "front 242", 1988));
            // see: here we are adding a group into a group and build up the hierarchy!!!!
            // 一个组可以加入到另一个组中  杜比音乐是工业音乐的一个分支组 分支的树枝
            industrialMusic.Add(dubstepMusic);
            dubstepMusic.Add(new Song("Centipede", "Knife Party", 2012));
            dubstepMusic.Add(new Song("Tetris", "doctor P", 2011));

            everySong.Add(heavyMetalMusic);
            heavyMetalMusic.Add(new Song("War Pigs", "Black Sabath", 1970));
            heavyMetalMusic.Add(new Song("Ace of spades", "Motorhead", 1980));

            // 电台主持人  拿到一个树形结构的音乐列表
            DiscJockey crazyLarry = new DiscJockey(everySong);
            crazyLarry.GetSongList();
        }
    }


    /// <summary>
    /// 抽象结点 == 歌曲
    /// </summary>
    public abstract class SongComponent
    {
        public virtual void Add(SongComponent component) { }
        public virtual void Remove(SongComponent component) { }
        public virtual SongComponent Get(int index) { return null; }

        public abstract void DisplaySongInformation();
    }


    /// <summary>
    /// 复合结点 枝干 -- 歌曲组 -- 专辑
    /// </summary>
    public class SongGroup : SongComponent
    {
        protected List<SongComponent> components = new List<SongComponent>();
        // 专辑有自己独有的属性
        public string groupName { get; protected set; }
        public string groupDescription { get; protected set; }

        public SongGroup(string name, string description)
        {
            this.groupName = name;
            this.groupDescription = description;
        }

        public override void Add(SongComponent component)
        {
            components.Add(component);
        }

        public override void Remove(SongComponent component)
        {
            components.Remove(component);
        }

        public override SongComponent Get(int i)
        {
            return components[i];
        }

        public override void DisplaySongInformation()
        {
            Debug.Log(groupName + " - " + groupDescription);

            // now iterate through all groups inside this group
            IEnumerator iterator = components.GetEnumerator();
            while (iterator.MoveNext())
            {
                SongComponent songComponent = (SongComponent)iterator.Current;
                songComponent.DisplaySongInformation();
            }
        }
    }

    // 叶子 -- 歌曲
    public class Song : SongComponent
    {
        // 歌曲有自己独有的属性
        public string songName { get; protected set; }
        public string bandName { get; protected set; }
        public int releaseYear { get; protected set; }

        public Song(string name, string band, int year)
        {
            this.songName = name;
            this.bandName = band;
            this.releaseYear = year;
        }

        public override void DisplaySongInformation()
        {
            Debug.Log("Song of " + songName + " - " + bandName + " : " + releaseYear);
        }
    }


    /// <summary>
    /// 音乐节目主持人
    /// </summary>
    public class DiscJockey
    {
        protected SongComponent songList;

        public DiscJockey(SongComponent songList)
        {
            this.songList = songList;
        }

        public void GetSongList()
        {
            songList.DisplaySongInformation();
        }
    }
}
