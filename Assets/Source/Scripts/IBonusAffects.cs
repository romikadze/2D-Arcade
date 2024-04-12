using System.Collections;
using Source.Scripts.GameEntities;

namespace Source.Scripts
{
    public interface IBonusAffects
    {
        public void StartAffect(Bonus bonus);
        
        public IEnumerator StopAffect(Bonus bonus);
    }
}