import {createStore} from 'vuex';

import coachModule from './modules/coach.js';

const store = createStore({
    modules:{
        coach:coachModule
    },
    state(){
        return{}
    },
    mutations:{

    },
    actions:{

    },
    getters:{

    }
});

export default store;