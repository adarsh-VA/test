<template>
  <section>
    <h2>My Friends</h2>
    <ul>
      <friend-element v-for="friend in friends" :key="friend.id" 
        v-bind="friend"
        @toggle-fav="favToggle"></friend-element>
    </ul>
  </section>
</template>

<script>
export default {
  data() {
    return {
      friends: [
        {
          id: "manuel",
          name: "Manuel Lorenz",
          phone: "0123 45678 90",
          email: "manuel@localhost.com",
          isFav:false
        },
        {
          id: "julie",
          name: "Julie Jones",
          phone: "0987 654421 21",
          email: "julie@localhost.com",
          isFav:true
        },
      ],
    };
  },
  methods:{
    favToggle(value){
      var freind = this.friends.find(f=>f.id===value);
      freind.isFav = !freind.isFav;
    }
  }
};
</script>