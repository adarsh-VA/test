

import MovieList from './pages/MovieList.vue';
import MovieAdd from './pages/MovieAdd.vue';



    export default [
        {path:'/',redirect:'/movies'},
        {path:'/movies',component:MovieList},
        {path:'/add',component:MovieAdd}
    ]
