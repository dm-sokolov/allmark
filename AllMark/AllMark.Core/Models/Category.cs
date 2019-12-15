namespace AllMark.Core.Models
{
    public class Category : BaseModel
    {
        public virtual int CategoryId { get; set; }

        /// <summary>
        /// наименование категории
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// идентификатор родительской категории
        /// </summary>
        public virtual int ParentId { get; set; }

        /// <summary>
        /// уровень в дереве категорий(1 верхний уровень, 2 подлежащий и так далее)
        /// </summary>
        public virtual int Level { get; set; }
    }
}
