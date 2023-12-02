using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using static Project1.Constants;
namespace Project1.Enemies.SpikeAdditonalFiles
{
    public class AxisBoundaryMaps
    {

        private static Dictionary<SPIKE_ID, List<Rectangle>> CreateSpikeBoundaryMapAxis()
        {
            Dictionary<SPIKE_ID, List<Rectangle>> idToRectangles = new Dictionary<SPIKE_ID, List<Rectangle>>();



            idToRectangles.Add(SPIKE_ID.TOP_LEFT, CreateTopLeft());
            idToRectangles.Add(SPIKE_ID.TOP_RIGHT, CreateTopRight());
            idToRectangles.Add(SPIKE_ID.BOTTOM_LEFT, CreateBotLeft());
            idToRectangles.Add(SPIKE_ID.BOTTOM_RIGHT, CreateBotRight());

            return idToRectangles;
        }

        private static List<Rectangle> CreateTopLeft()
        {
            List<Rectangle> axisBoundingBoxList = new List<Rectangle>();
            int x = GetSpikeLocalPosition(SPIKE_ID.TOP_LEFT).Item1;
            int y = GetSpikeLocalPosition(SPIKE_ID.TOP_LEFT).Item2;

            Rectangle axisX = new Rectangle(roomBoundsMinX,roomBoundsMinY,roomBoundsMaxX,SPIKE_HEIGHT * DOUBLE);
            Rectangle axisY = new Rectangle(x,y,SPIKE_WIDTH * DOUBLE, roomBoundsMaxY);

            axisBoundingBoxList.Add(axisX);
            axisBoundingBoxList.Add(axisY);

            return axisBoundingBoxList;
        }
        private static List<Rectangle> CreateTopRight()
        {
            List<Rectangle> axisBoundingBoxList = new List<Rectangle>();
            int x = GetSpikeLocalPosition(SPIKE_ID.TOP_RIGHT).Item1;
            int y = GetSpikeLocalPosition(SPIKE_ID.TOP_RIGHT).Item2;

            Rectangle axisX = new Rectangle(roomBoundsMinX, roomBoundsMinY, roomBoundsMaxX, SPIKE_HEIGHT * DOUBLE);
            Rectangle axisY = new Rectangle(x-SPIKE_WIDTH, roomBoundsMinY, SPIKE_WIDTH * DOUBLE, roomBoundsMaxY);

            axisBoundingBoxList.Add(axisX);
            axisBoundingBoxList.Add(axisY);

            return axisBoundingBoxList;
        }
        private static List<Rectangle> CreateBotLeft()
        {
            List<Rectangle> axisBoundingBoxList = new List<Rectangle>();
            int x = GetSpikeLocalPosition(SPIKE_ID.BOTTOM_LEFT).Item1;
            int y = GetSpikeLocalPosition(SPIKE_ID.BOTTOM_LEFT).Item2;

            Rectangle axisX = new Rectangle(x, y - SPIKE_HEIGHT, roomBoundsMaxX, SPIKE_HEIGHT * DOUBLE);
            Rectangle axisY = new Rectangle(x - SPIKE_WIDTH, roomBoundsMinY, SPIKE_WIDTH * DOUBLE, roomBoundsMaxY);

            axisBoundingBoxList.Add(axisX);
            axisBoundingBoxList.Add(axisY);

            return axisBoundingBoxList;
        }

        private static List<Rectangle> CreateBotRight()
        {
            List<Rectangle> axisBoundingBoxList = new List<Rectangle>();
            int x = GetSpikeLocalPosition(SPIKE_ID.BOTTOM_RIGHT).Item1;
            int y = GetSpikeLocalPosition(SPIKE_ID.BOTTOM_RIGHT).Item2;

            Rectangle axisX = new Rectangle(roomBoundsMinX, y-SPIKE_HEIGHT, roomBoundsMaxX, SPIKE_HEIGHT * DOUBLE);
            Rectangle axisY = new Rectangle(x - SPIKE_WIDTH, roomBoundsMinY, SPIKE_WIDTH * DOUBLE, roomBoundsMaxY);

            axisBoundingBoxList.Add(axisX);
            axisBoundingBoxList.Add(axisY);

            return axisBoundingBoxList;
        }
        private static Dictionary<(int, int), SPIKE_ID> CreatePositionToIdMap()
        {
            Dictionary<(int, int), SPIKE_ID> AssignID = new Dictionary<(int, int), SPIKE_ID>();

            AssignID.Add(TL_SPIKE, SPIKE_ID.TOP_LEFT);
            AssignID.Add(TR_SPIKE, SPIKE_ID.TOP_RIGHT);
            AssignID.Add(BL_SPIKE, SPIKE_ID.BOTTOM_LEFT);
            AssignID.Add(BR_SPIKE, SPIKE_ID.BOTTOM_RIGHT);

            return AssignID;
        }

        private static Dictionary<SPIKE_ID, (int, int)> CreateSpikeIdToLocalPosition()
        {
            Dictionary<SPIKE_ID, (int, int)> AssignLocalPos = new Dictionary<SPIKE_ID, (int, int)>();

            PositionGrid.getPosBasedOnGrid(TL_SPIKE.Item1,TL_SPIKE.Item2);
            AssignLocalPos.Add(SPIKE_ID.TOP_LEFT, PositionGrid.getPosBasedOnGrid(TL_SPIKE.Item1, TL_SPIKE.Item2));
            AssignLocalPos.Add(SPIKE_ID.TOP_RIGHT, PositionGrid.getPosBasedOnGrid(TR_SPIKE.Item1, TR_SPIKE.Item2));
            AssignLocalPos.Add(SPIKE_ID.BOTTOM_LEFT, PositionGrid.getPosBasedOnGrid(BL_SPIKE.Item1, BL_SPIKE.Item2));
            AssignLocalPos.Add(SPIKE_ID.BOTTOM_RIGHT,PositionGrid.getPosBasedOnGrid(BR_SPIKE.Item1, BR_SPIKE.Item2));

            return AssignLocalPos;
        }


        public static (int,int) GetSpikeLocalPosition(SPIKE_ID id)
        {
            Dictionary<SPIKE_ID, (int, int)> IDLocalPos = CreateSpikeIdToLocalPosition();
            return IDLocalPos.GetValueOrDefault(id);
        }

        public static SPIKE_ID GetSpikeID((int,int) pos)
        {
            Dictionary<(int, int), SPIKE_ID> gridToID = CreatePositionToIdMap();
            return gridToID.GetValueOrDefault(pos);
        }

        public static List<Rectangle> GetSpikeAxisBoxes(SPIKE_ID id)
        {
            Dictionary < SPIKE_ID, List < Rectangle >> idToBoxes = CreateSpikeBoundaryMapAxis();
            return idToBoxes.GetValueOrDefault(id);
        }
    }


    
}
