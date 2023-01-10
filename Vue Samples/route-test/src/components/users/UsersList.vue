<template>
  <button @click="saveChanges()">Save Changes</button>
  <ul>
    <user-item v-for="user in users" :key="user.id" :name="user.fullName" :role="user.role"></user-item>
  </ul>
</template>

<script>
import UserItem from './UserItem.vue';

export default {
  components: {
    UserItem,
  },
  inject: ['users'],
  data(){
    return {
      savedChanges:false
    }
  },
  methods:{
    saveChanges(){
      this.savedChanges = true;
    }
  },
  beforeRouteLeave(_to,_from,next){
    console.log("route leaving from the users list",this.savedChanges);

    if(this.savedChanges){
      next();
    }
    else{
      var userSelected = confirm("Are You Sure? You got some unsaved changes!!");
      next(userSelected);
    }
  }
};
</script>

<style scoped>
ul {
  list-style: none;
  margin: 2rem auto;
  max-width: 20rem;
  padding: 0;
}
</style>