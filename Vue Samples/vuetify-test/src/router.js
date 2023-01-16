

import MovieList from './pages/MovieList.vue';
import MovieAdd from './pages/MovieAdd.vue';
import NotFound from './components/NotFound.vue';



    export default [
        {path:'/',redirect:'/movies'},
        {path:'/movies',component:MovieList , props:true,
            children:[{path:':id',component:NotFound}]
        },
        {path:'/add',component:MovieAdd}
    ]
