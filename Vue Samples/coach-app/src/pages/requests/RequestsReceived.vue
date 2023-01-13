<template>
    <div>
        <base-card>
            <header>
                <h2>Requests Received</h2>
            </header>
            <ul v-if="hasRequests">
                <request-item v-for="req in coachRequests" :key="req.id" :email="req.userEmail" :message="req.message"></request-item>
            </ul>
            <h3 v-else>You Haven't Received any requests yet!</h3>
        </base-card>
    </div>
</template>


<script>
import requestItem from '@/components/requests/requestItem.vue';

export default{
    components:{
        requestItem
    },
    computed:{
        coachRequests(){
            return this.$store.getters['request/requests'];
        },
        hasRequests(){
            return this.$store.getters['request/hasRequests'];
        }
    },
    created(){
        this.$store.dispatch('request/fetchRequests');
    }
}
</script>

<style scoped>
header {
  text-align: center;
}

ul {
  list-style: none;
  margin: 2rem auto;
  padding: 0;
  max-width: 30rem;
}

h3 {
  text-align: center;
}
</style>