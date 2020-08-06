import {NgModule} from "@angular/core";
import {RouterModule, Routes} from "@angular/router";
import {AccountComponent} from "./account/account.component";
import {RegisterComponent} from "./account/register/register.component";
import {ViewOrdersComponent} from "./view-orders/view-orders.component";
import {ShopComponent} from "./shop/shop.component";
import {AdminComponent} from "./admin/admin.component";
import {AuthGuard} from "./auth/auth.guard";

const appRoutes: Routes = [
  {path: '', redirectTo: '', pathMatch: 'full'},
  {path: 'orders', component: ViewOrdersComponent},
  {path: 'shop',component: ShopComponent},
  {path: 'admin', component: AdminComponent},
  {path: 'account', component: AccountComponent, children: [
      {path: 'register', component: RegisterComponent},
    ]},
  {path: '', redirectTo: '', pathMatch: 'full'},
]

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
