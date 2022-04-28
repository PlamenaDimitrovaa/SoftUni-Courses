// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
  using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        private Stage stage = null;

        [SetUp]
        public void InitTest()
        {
            stage = new Stage();
        }

        [Test]
        public void PerformerCannotBeNullInAddPerformer()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null), "Can not be null!");
        }

        [Test]
        public void PerformerUnder18lInAddPerformer()
        {
            var performer = new Performer("Plamena", "Dimitrova", 9);
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
        }

        [Test]
        public void PerformerAddedSuccessfullyInAddPerformer()
        {
            var performer = new Performer("Plamena", "Dimitrova", 29);
            stage.AddPerformer(performer);
            Assert.AreEqual(1, stage.Performers.Count);
            Assert.That(stage.Performers.FirstOrDefault().Equals(performer));
        }

        [Test]
        public void SongCannotBeNullInAddSong()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
        }

        [Test]
        public void SongDurationUnder1MinuteInAddSong()
        {
            var song = new Song("White rabbit", new TimeSpan(0, 0, 34));
            Assert.Throws<ArgumentException>(() => stage.AddSong(song));
        }

        [Test]
        public void SongNameAndPerformerNameMustNotBeNullInAddSongToPerformer()
        {
            Assert.Throws<ArgumentNullException>(() =>
            stage.AddSongToPerformer(null, "Plamena"));
            Assert.Throws<ArgumentNullException>(() =>
            stage.AddSongToPerformer("White rabbit", null));
        }

        [Test]
        public void AddSongToPerformerSongAdded()
        {
            var performer = new Performer("Plamena", "Dimitrova", 29);
            var song = new Song("White rabbit", new TimeSpan(0, 1, 34));

            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("White rabbit", "Plamena Dimitrova");

            Assert.AreEqual(1, performer.SongList.Count);
            Assert.That(performer.SongList.FirstOrDefault().Equals(song));
        }
        
        [Test]
        public void StagePlayReturnsRightNumbers()
        {
            var performer = new Performer("Plamena", "Dimitrova", 29);
            var song = new Song("White rabbit", new TimeSpan(0, 1, 34));

            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("White rabbit", "Plamena Dimitrova");

            string result = stage.Play();
            Assert.That(result == "1 performers played 1 songs");
        }

        [Test]
        public void AddSongToPerformerSongNotExists()
        {
            var performer = new Performer("Plamena", "Dimitrova", 29);

            stage.AddPerformer(performer);

            Assert.Throws<ArgumentException>(() =>
            stage.AddSongToPerformer("White rabbit", "Plamena Dimitrova"));
        }

        [Test]
        public void AddSongToPerformerPerformerNotExists()
        {
            var song = new Song("White rabbit", new TimeSpan(0, 1, 34));
            stage.AddSong(song);

            Assert.Throws<ArgumentException>(() =>
            stage.AddSongToPerformer("White rabbit", "Plamena Dimitrova"));
        }
    }
}