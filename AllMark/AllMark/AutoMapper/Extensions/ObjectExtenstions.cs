using AutoMapper;

namespace AllMark.AutoMapper.Extensions
{
    public static class ObjectExtenstions
    {
        public static T MapTo<T>(this object obj, IMapper mapper) => mapper.Map<T>(obj);
    }
}
