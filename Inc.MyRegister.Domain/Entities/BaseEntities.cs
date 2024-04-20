namespace Inc.MyRegister.Domain.Entities
{
    public class BaseEntities
    {
        public int Id { get; private set; }

        public BaseEntities(int id)
        {
            Id = id;
        }

        public BaseEntities() { }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
