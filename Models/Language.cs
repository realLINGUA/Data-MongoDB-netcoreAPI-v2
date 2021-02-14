using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// BSON types are listed https://docs.mongodb.com/manual/reference/bson-types/ 
// string is UTF-8
// double
// ObjectId = guid, mark the default index with [BsonId], insert to database will generate this automaticalkly (no need to set)
// List<> = array

//var document = new BsonDocument {
//    { "author", "joe" },
//    { "title", "yet another blog post" },
//    { "text", "here is the text..." },
//    { "tags", new BsonArray { "example", "joe" } },
//    { "comments", new BsonArray {
//        new BsonDocument { { "author", "jim" }, { "comment", "I disagree" } },
//        new BsonDocument { { "author", "nancy" }, { "comment", "Good post" } }
//    }}
//};

//BsonDocument doc = new BsonDocument {
//    { "author", "joe" },
//        { "title", "yet another blog post" },
//     { "text", "here is the text..." }
//};
//BsonArray array1 = new BsonArray {
//        "example", "joe"
//    };
//BsonArray array2 = new BsonArray {
//        new BsonDocument { { "author", "jim" }, { "comment", "I disagree" } },
//        new BsonDocument { { "author", "nancy" }, { "comment", "Good post" } }
//    };
//doc.Add("tags", array1);
//doc.Add("comments", array2);

namespace rlRepository.Models
{
    public class Language
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Language")]
        public string LanguageName { get; set; }

        [BsonElement("ISOCode")]
        // from ISO 639-1
        public string ISOLanguageCode { get; set; }
        
        public string Description { get; set; }

        public string ThumbnailImageURL { get; set; }
        public string HeaderImageURL { get; set; }
        // public BsonBinaryData Thumbnail { get; set; }

        // characters used in this language
        public Alphabet Alphabet { get; set; }

        // major product identifier (requires level as well)
        public string SKU { get; set; }
        public List<LanguageLevel> LanguageLevels { get; set; }
        public bool Active { get; set; }

        #region deprecated
        public string Origin { get; set; }
        public string Region { get; set; }
        #endregion
    }

    public class Alphabet
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public List<string> Character { get; set; } // UTF-8 character set

        // UTF-8 characters listed at https://www.fileformat.info/info/charset/UTF-8/list.htm
        // string str = "\u24c8 \u2075 \u221e";

        // French characters include regular Latin alphabet (26 characters, lower and upper) plus:

        // upper-case
        // c380       À
        // c381       Á
        // c382       Â
        // c387       Ç
        // c388       È
        // c389       É
        // c38a       Ê
        // c38c       Ì
        // c38d       Í
        // c38e       Î

        // c392       Ò
        // c393       Ó
        // c394       Ô
        // c399       Ù
        // c39a       Ú
        // c39b       Û

        // lower-case...
        // c3a0       à
    }

    public class LanguageLevel  // realFrench 101
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Level")]
        public string LevelName { get; set; }
        [BsonElement("LevelTitle")]
        public string Title { get; set; }   // for HTML pages
        public string Description { get; set; }
        public string GoText { get; set; }
        public string StartPageText { get; set; }
        public string FinishPageText { get; set; }
        public string Encouragement { get; set; }
        public bool Active { get; set; }

        public List<SubscriptionSKU> SubscriptionSKUs { get; set; }
    }

    public class SubscriptionSKU
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string SKUName { get; set; }     // realFrench 101 for US Market
        public double SKUPrice { get; set; }    // 99.99, or discounted price (may add a List<CouponCode> to SubscriptionSKU for this reason
        public string SKUCurrency { get; set; } // USD
        public TimeSpan SKUDuration { get; set; }   // 6 months, etc.; if not specified then no end date
        // public TimeSpan SKUBillFrequency { get; set; }  // will determine if quartly billed, monthly, etc.
        public bool Active { get; set; }
    }
}