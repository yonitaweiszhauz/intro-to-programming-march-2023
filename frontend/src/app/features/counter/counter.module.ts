import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CounterComponent } from './counter.component';
import { StoreModule } from '@ngrx/store';
import { featureName, reducers } from './state';
import { CounterPrefsComponent } from './components/counter-prefs/counter-prefs.component';
import { CounterEffects } from './state/effects/counter.effect';
import { EffectsModule } from '@ngrx/effects';

@NgModule({
  declarations: [
    CounterComponent,
    CounterPrefsComponent,
  ],
  imports: [
    CommonModule,
    StoreModule.forFeature(featureName, reducers),
    EffectsModule.forFeature([CounterEffects]),
  ],
  exports: [CounterComponent],
})
export class CounterModule {}
