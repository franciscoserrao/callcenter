namespace CallCenter.AgentsService.Repository.Data.MongoDB
{
    using CallCenter.DTO.Enum;
    using global::MongoDB.Bson;
    using global::MongoDB.Bson.Serialization.Attributes;

    public class MongoAgentData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string id { get; set; }
        public string name { get; set; }
        public AgentState state { get; set; }
        public List<Guid> skills { get; set; }
    }
}
