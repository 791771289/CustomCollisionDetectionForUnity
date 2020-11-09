using UnityEngine;

namespace navid021.CustomCollisionDetection
{
    namespace CustomAreaBound
    {
        public struct AreaBound
        {
            public Vector3 position;
            public Vector3 scale;

            public float xMin {
                get {
                    return this.position.x + -ResponseScale.x;
                }
            }

            public float xMax {
                get {
                    return this.position.x + ResponseScale.x;
                }
            }

            public float yMin {
                get {
                    return this.position.y + -ResponseScale.y;
                }
            }

            public float yMax {
                get {
                    return this.position.y + ResponseScale.y;
                }
            }

            public float zMin {
                get {
                    return this.position.z + -ResponseScale.z;
                }
            }

            public float zMax {
                get {
                    return this.position.z + ResponseScale.z;
                }
            }

            public Vector3 ResponseScale {
                get {
                    return this.scale / 2;
                }
            }

            //public AreaBound(float posx, float posy, float posz, float sizex, float sizey, float sizez)
            //{
            //    this.position.x = posx;
            //    this.position.y = posy;
            //    this.position.z = posz;
            //    this.scale.x = sizex;
            //    this.scale.y = sizey;
            //    this.scale.z = sizez;
            //}

            public AreaBound(Vector3 position, Vector3 scale)
            {
                this.position = position;
                this.scale = scale;
            }

            public bool OverLaps(Vector3 point)
            {
                return OverLaps(point, Vector3.zero);
            }

            public bool OverLaps(Vector3 point, Vector3 sizeDelta)
            {
                return ((point.x + sizeDelta.x >= this.xMin && point.x + -sizeDelta.x <= this.xMax) && (point.y + sizeDelta.y >= this.yMin && point.y + -sizeDelta.y <= this.yMax) && (point.z + sizeDelta.z >= this.zMin && point.z + -sizeDelta.z <= this.zMax));
            }
        }
    }
}