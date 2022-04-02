using UnityEngine;

namespace Platformer2d.Movements
{
    public class EnemyScaleFlip : IFlip
    {
        readonly Transform _body;
        
        public EnemyScaleFlip(Transform body)
        {
            _body = body;
        }
        
        public void FlipProcess()
        {
            float xScale = _body.localScale.x * -1f;
            _body.localScale = new Vector3(xScale, 1f, 1f);
        }
    }
}