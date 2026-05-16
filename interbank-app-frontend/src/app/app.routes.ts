import { Routes } from '@angular/router';
import { HomeLayout } from './home/layouts/home-layout/home-layout';
import { HomePage } from './home/pages/home-page/home-page';
import { AuthLayout } from './auth/layouts/auth-layout/auth-layout';
import { LoginPage } from './auth/pages/login-page/login-page';
import { AdminLayout } from './admin/layout/admin-layout/admin-layout';
import { AdminPage } from './admin/pages/admin-page/admin-page';

export const routes: Routes = [

    {
        path: 'home',
        component:HomeLayout,
        children : [
            {path:'',component:HomePage},
            {path:'**',redirectTo:'',pathMatch:'full'}
        ]
    },
    {
        path:'admin',
        component : AdminLayout,
        children:[
            {path:'home',component:AdminPage},
            {path:'**',redirectTo:'home',pathMatch:'full'}
        ]
    },
    {
        path:'',
        component:AuthLayout,
        children:[
            {path:'login',component:LoginPage},
            {path:'**',redirectTo:'login',pathMatch:'full'}
        ]
    },
    {
        path:'**',
        redirectTo:'home',
        pathMatch:'full'
    }

];
