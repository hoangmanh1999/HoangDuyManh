using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab11.Model.Sound;

namespace Lab11.Model
{
    public class SoundManager
    {
        private static List<Sound> GetSounds()
        {
            var sounds = new List<Sound>();

            sounds.Add(new Sound("Cow", Sound.SoundCategory.Animals));
            sounds.Add(new Sound("Cat", Sound.SoundCategory.Animals));

            sounds.Add(new Sound("Gun", Sound.SoundCategory.Cartoons));
            sounds.Add(new Sound("Spring", Sound.SoundCategory.Cartoons));

            sounds.Add(new Sound("Clock", Sound.SoundCategory.Taunts));
            sounds.Add(new Sound("Lol", Sound.SoundCategory.Taunts));

            sounds.Add(new Sound("Ship", Sound.SoundCategory.Warnings));
            sounds.Add(new Sound("Siren", Sound.SoundCategory.Warnings));

            return sounds;
        }

        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allsounds = GetSounds();
            sounds.Clear();
            allsounds.ForEach(p => sounds.Add(p));
        }

        public static void GetSoundsByCategory(ObservableCollection<Sound> sounds,SoundCategory soundCategory)
        {
            var allSounds = GetSounds();
            var filteredSounds = allSounds.Where(p => p.Category == soundCategory).ToList();
            sounds.Clear();
            filteredSounds.ForEach(p => sounds.Add(p));
        }
        public static void GetSoundByName(ObservableCollection<Sound> sounds, string name)
        {
            var allSounds = GetSounds();
            var filteredSounds = allSounds.Where(p => p.Name == name).ToList();
            sounds.Clear();
            filteredSounds.ForEach(p => sounds.Add(p));
        }
        
    }
}
