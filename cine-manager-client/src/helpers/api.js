export class MoviesApi{
    static getMovies(){
        console.log("Movies Api - getMovies()")
        return [
            {
              title:'Iron Man',
              img_url:'www.image.com',
              description:'Tony Stark inventou armadura ...',
              duration:145,
            },
            {
              title:'007',
              img_url:'www.image.com',
              description:'O agente secreto mais famoso do cimema ...',
              duration:90,
            },
            {
              title:'Harry Potter e o Prisioneiro de Ascaban',
              img_url:'www.image.com',
              description:'Harry encontra um novo desafio ...',
              duration:160,
            },
            {
              title:'Senhor dos Anéis',
              img_url:'www.image.com',
              description:'Um mistério envolvendo um anel amaldiçoado ...',
              duration:180,
            },
            {
              title:'Hulk',
              img_url:'www.image.com',
              description:'O doutor inventou ...',
              duration:125,
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

export class SessionsApi{
  static getSessions(){
      console.log("Sessions Api - getSessions()")
      return [
          {
            date:'14/11/2021',
            ini_time:'13:00',
            end_time:'14:30',
            ticket_price:'30,00',
            animation:'3D',
            audio:'Dublado',
            movie:'Hulk',
            room:'Sala 01'
          },
          {
            date:'14/11/2021',
            ini_time:'15:00',
            end_time:'16:30',
            ticket_price:'30,00',
            animation:'3D',
            audio:'Dublado',
            movie:'Hulk',
            room:'Sala 01'
          },
          {
            date:'14/11/2021',
            ini_time:'17:00',
            end_time:'18:30',
            ticket_price:'30,00',
            animation:'3D',
            audio:'Dublado',
            movie:'Hulk',
            room:'Sala 01'
          },
          {
            date:'14/11/2021',
            ini_time:'13:00',
            end_time:'14:30',
            ticket_price:'30,00',
            animation:'2D',
            audio:'Legendado',
            movie:'Iron Man',
            room:'Sala 02'
          },
          {
            date:'14/11/2021',
            ini_time:'15:00',
            end_time:'16:30',
            ticket_price:'30,00',
            animation:'2D',
            audio:'Legendado',
            movie:'Iron Man',
            room:'Sala 02'
          },
          {
            date:'14/11/2021',
            ini_time:'13:00',
            end_time:'14:30',
            ticket_price:'30,00',
            animation:'3D',
            audio:'Legendado',
            movie:'Senhor dos Anéis',
            room:'Sala 03'
          },
          {
            date:'14/11/2021',
            ini_time:'15:00',
            end_time:'16:30',
            ticket_price:'30,00',
            animation:'3D',
            audio:'Legendado',
            movie:'Senhor dos Anéis',
            room:'Sala 03'
          },
          {
            date:'14/11/2021',
            ini_time:'17:00',
            end_time:'18:30',
            ticket_price:'30,00',
            animation:'3D',
            audio:'Legendado',
            movie:'Senhor dos Anéis',
            room:'Sala 03'
          },
        ];
  }

  static getSession(id){
      return id;
  }

  static updateSession(id){
      return id;
  }
  
  static postSession(){
      return;
  }

  static deleteSession(id){
      return id;
  }

}

export class RoomsApi{
  static getRooms(){
      console.log("Rooms Api - getRooms()")
      return [
        {
          name:'Sala 01',
          seats_number:100,
        },
        {
          name:'Sala 02',
          seats_number:160,
        },
        {
          name:'Sala 03',
          seats_number:90,
        },
        ];
  }

  static getRoom(id){
      return id;
  }

  static updateRoom(id){
      return id;
  }
  
  static postRoom(){
      return;
  }

  static deleteRoom(id){
      return id;
  }

}