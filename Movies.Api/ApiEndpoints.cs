namespace Movies.Api
{
    public static class ApiEndpoints
    {
        private const string Base = "api";
        public static class Movies
        {
            private const string Controller = "movies";
            public const string Create = $"{Base}/{Controller}";
            public const string GetAll = $"{Base}/{Controller}";
            public const string GetById = $"{Base}/{Controller}/{{id:guid}}";
            public const string Update = $"{Base}/{Controller}/{{id:guid}}";
            public const string Delete = $"{Base}/{Controller}/{{id:guid}}";
        }
    }
}