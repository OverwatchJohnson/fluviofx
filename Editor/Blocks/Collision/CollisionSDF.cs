using System.Collections.Generic;
using System.Linq;
using UnityEditor.VFX;
using UnityEngine;

namespace Thinksquirrel.FluvioFX.Editor.Blocks
{
    [VFXInfo(category = "FluvioFX/Collision")]
    class CollisionSDF : UnityEditor.VFX.Block.CollisionSDF, ICollisionSettings
    {
        public override string name
        {
            get
            {
                return "Fluid Collider (Signed Distance Field)";
            }
        }

        [VFXSetting]
        public bool boundaryPressure = true;
        [VFXSetting]
        public bool boundaryViscosity = true;
        [VFXSetting]
        public bool repulsionForce = false;

        public bool BoundaryPressure => boundaryPressure;

        public bool BoundaryViscosity => boundaryViscosity;

        public bool RepulsionForce => repulsionForce;

        public bool RoughSurface => roughSurface;

        public override IEnumerable<string> includes =>
            FluvioFXCollisionUtility.GetIncludes(base.includes);
        public override IEnumerable<VFXNamedExpression> parameters =>
            FluvioFXCollisionUtility.GetParameters(this, base.parameters);
        protected override IEnumerable<VFXPropertyWithValue> inputProperties =>
            FluvioFXCollisionUtility.GetInputProperties(this, base.inputProperties);
        public override IEnumerable<VFXAttributeInfo> attributes =>
            FluvioFXCollisionUtility.GetAttributes(base.attributes);

        public override string source =>
            FluvioFXCollisionUtility.GetCollisionSource(
                this,
                base.source,
                collisionResponseSource,
                roughSurfaceSource);
    }
}
