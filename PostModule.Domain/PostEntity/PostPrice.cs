﻿using _Utilities.Domain;

namespace PostModule.Domain.PostEntity
{
    public class PostPrice :BaseEntity<int>
    {
        public int PostId { get; private set; }
        public int Start { get; private set; }
        public int End { get; private set; }
        public int TehranPrice { get; private set; }
        public int StateCenterPrice { get; private set; }
        public int CityPrice { get; private set; }
        public int InsideStatePrice { get; private set; }
        public int StateClosePrice { get; private set; }
        public int StateNonClosePrice { get; private set; }
        public Post Post { get; set; }
        public PostPrice()
        {
            
        }
        public PostPrice(int postId, int start, int end, int tehranPrice,
            int stateCenterPrice, int cityPrice, int insideStatePrice,
            int stateClosePrice, int stateNonClosePrice)
        {
            PostId = postId;
            Start = start;
            End = end;
            TehranPrice = tehranPrice;
            StateCenterPrice = stateCenterPrice;
            CityPrice = cityPrice;
            InsideStatePrice = insideStatePrice;
            StateClosePrice = stateClosePrice;
            StateNonClosePrice = stateNonClosePrice;
        }
        public void Edit(int start, int end, int tehranPrice,
            int stateCenterPrice, int cityPrice, int insideStatePrice,
            int stateClosePrice, int stateNonClosePrice)
        {
            Start = start;
            End = end;
            TehranPrice = tehranPrice;
            StateCenterPrice = stateCenterPrice;
            CityPrice = cityPrice;
            InsideStatePrice = insideStatePrice;
            StateClosePrice = stateClosePrice;
            StateNonClosePrice = stateNonClosePrice;
        }
    }
}