export class MoviesApi{
    static getMovies(){
        console.log("Movies Api - getMovies()")
        return [
            {
              title:'Iron Man',
              img_url:'www.image.com',
              description:'Tony Stark inventou armadura ...',
              duration:'145 min',
            },
            {
              title:'007',
              img_url:'www.image.com',
              description:'O agente secreto mais famoso do cimema ...',
              duration:'90 min',
            },
            {
              title:'Harry Potter e o Prisioneiro de Ascaban',
              img_url:'www.image.com',
              description:'Harry encontra um novo desafio ...',
              duration:'160 min',
            },
            {
              title:'Senhor dos Anéis',
              img_url:'www.image.com',
              description:'Um mistério envolvendo um anel amaldiçoado ...',
              duration:'180 min',
            },
            {
              title:'Hulk',
              img_url:'www.image.com',
              description:'O doutor inventou ...',
              duration:'125 min',
            },
          ];
    }

    static getMovie(id){
        return id;
    }

    static updateMovie(id){
        return id;
    }
    
    static postMovie(){
        return;
    }

    static deleteMovie(id){
        return id;
    }

}