<template>
    <v-card width="280px" class="pa-2 mx-auto card">
        <img :src="require(`@/assets/imgs/avengers.jpg`)" alt="Card image" height="300px" width="100%">
        <v-card-title class="pa-2">
          {{ name }}
        </v-card-title>
        <v-card-text class="pa-2">
          {{ plot }}
        </v-card-text>
        <v-card-actions class="pa-2">
          
          <!-- dailog for Movie Details -->
          <v-dialog
            v-model="dialog"
            width="500"
          >
            <template v-slot:activator="{ on, attrs }">
              <v-btn color="info" plain class="pa-0" v-bind="attrs"
                v-on="on">Explore <i class="fa fa-arrow-right"></i></v-btn>
            </template>
          
            <v-card class="pa-2">
              
              <v-img :src="require(`@/assets/imgs/avengers.jpg`)" height="300px" contain class="dailog-img mb-3"></v-img>
              <hr>
              <v-card-title>
                {{ name }}
              </v-card-title>

              <v-card-text class="pb-0">
                <p><b>Actors:</b> {{ loadActors }}</p> 
              </v-card-text>
              <v-card-text class="pb-0">
                <p><b>Producer:</b> {{ producer.name }}</p> 
              </v-card-text>
              <v-card-text class="pb-0">
                <p><b>Genre:</b> {{ loadGenres }}</p> 
              </v-card-text>
              <v-card-text class="pb-0">
                <p><b>Plot:</b>{{ plot }}</p> 
              </v-card-text>
            
              <v-divider></v-divider>
            
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn
                  color="primary"
                  text
                  @click="dialog = false"
                >
                  Close
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
          <v-spacer></v-spacer>
          <div>
              <a href="" class="mx-1"><i class="fa-regular fa-pen-to-square"></i></a>
              <a href="" class="red--text"><i class="fa-regular fa-trash-can"></i></a>
          </div>
        </v-card-actions>
      </v-card>
</template>

<script>
export default{
    props:['id','name','actors','genres','plot','producer','YOR'],
    data(){
      return{
        dialog:false,
      }
    },
    computed:{
        loadActors(){
          var actors = this.actors;
          var len = actors.length;
          var result = '';
          for(var i=0;i<len-1;i++){
            result += actors[i].name + ', '
          }
          result += actors[len-1].name;
          return result;
        },
        loadGenres(){
          var genres = this.genres;
          var len = genres.length;
          var result = '';
          for(var i=0;i<len-1;i++){
            result += genres[i].name + ', '
          }
          result += genres[len-1].name;
          return result;
        }
    }
}
</script>

<style scoped>

.card{
    backdrop-filter: blur(5px);
    background-color: rgba(255, 255, 255, 0.726);
}

.card:hover{
    transition: transform 0.3s;
    box-shadow: 0 0px 10px 2px #212121;
}

</style>