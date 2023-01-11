<template>
  <li>
    <h2>{{ name }} {{ isFav ? 'Favourite': ''}}</h2>
    <button @click="show()">{{ showDetails?'Hide':'Show' }} Details</button>
    <button @click="toggleFav()">Add Fav</button>
    <ul v-if="showDetails">
      <li>{{ phoneNumber }}</li>
      <li>{{ email }}</li>
    </ul>
  </li>
</template>

<script>
export default {
  props:['id','name','phoneNumber','email','isFav'],
  data(){
    return{
      showDetails:false
    }
  },
  methods:{
    show(){
      this.showDetails=!this.showDetails;
    },
    toggleFav(){
      this.$emit('toggle-fav',this.id)
    }
  }
}
</script>