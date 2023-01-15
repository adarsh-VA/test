<template>
    <v-card width="280px" class="pa-2 mx-auto card">
        <img :src="require(`@/assets/imgs/${name}.jpg`)" alt="Card image" height="300px" width="100%">
        <v-card-title class="pa-2">
          {{ name }}
        </v-card-title>
        <v-card-text class="pa-2">
          Lorem ipsum dolor sit amet and i go consectetur, adipisicing elit. Dignios, rerum error.
        </v-card-text>
        <v-card-actions class="pa-2">
          <v-btn color="info" plain class="pa-0">Explore <i class="fa fa-arrow-right"></i></v-btn>
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
    props:['name'],
    computed:{
        movieLink(){
            var images = "@/assets/imgs";
            return images+'/'+this.name+'.jpg';
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
    transform: scale(1.05);
    transition: transform 0.3s;
    box-shadow: 0 0px 10px 2px #212121;
}

</style>