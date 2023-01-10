import {createRouter,createWebHistory} from 'vue-router';


import TeamsList from './components/teams/TeamsList.vue';
import UsersList from './components/users/UsersList.vue';
import TeamMembers from './components/teams/TeamMembers.vue';
import TheFooter from './components/footer/TheFooter.vue';

const router = createRouter({
    history:createWebHistory(),
    routes:[
        {
            name:'teams',
            path: '/teams',components:{default:TeamsList,footer:TheFooter},
            children:[
                {name:'team-members',path:':teamId',component:TeamMembers,props:true}
            ]
        },
        {name:'users',path: '/users',component:UsersList},
        {name:'invalid-route',path:'/:notFound(.*)',redirect:'/teams'}
        // {path:'/:.*',redirect:'/teams'}
    ],
    linkActiveClass:'active',
    scrollBehavior(_to,_from,savedPosition){
        if(savedPosition)
            return {savedPosition}
        return{left:0,top:0}
    }
});

router.afterEach((to,from)=>{
    console.log(to,from);
});

export default router;
