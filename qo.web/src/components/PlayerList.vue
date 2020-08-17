<template>
  <v-expansion-panels hover multiple popout :value="[0]">
    <v-expansion-panel>
      <v-expansion-panel-header class="text-h5 info white--text font-weight-light">
        <span>
          <v-icon class="white--text mb-1 mr-2">fas fa-calculator</v-icon>
          Calculation Details
        </span>
        </v-expansion-panel-header>
      <v-expansion-panel-content class="secondary--text pt-6">
        The qualifying offer is a one-year contract, the value of which is calculated by averaging the highest {{ topQuantity }} player salaries from the prior season.
        {{ excludedPlayers.length }} players could not be considered in this calculation due to missing salary data for the previous season.
      </v-expansion-panel-content>
    </v-expansion-panel>
    <v-expansion-panel>
      <v-expansion-panel-header class="text-h5 info white--text font-weight-light">
        <span>
          <v-icon class="white--text mb-1 mr-1">fas fa-users</v-icon>
          Included Players
        </span>
      </v-expansion-panel-header>
      <v-expansion-panel-content class="info--text pt-6">
        <v-list rounded>
          <PlayerPill v-for="(player, index) in includedPlayers" :player="player" :key="index" :rank="index + 1"/>
        </v-list>
      </v-expansion-panel-content>
    </v-expansion-panel>
    <v-expansion-panel>
      <v-expansion-panel-header class="text-h5 info white--text font-weight-light">
        <span>
          <v-icon class="white--text mb-1 mr-1">fas fa-users-slash</v-icon>
          Excluded Players
        </span>
      </v-expansion-panel-header>
      <v-expansion-panel-content class="info--text pt-6">
        <v-list rounded>
          <PlayerPill v-for="(player, index) in excludedPlayers" :player="player" :key="index" :rank="index + 1"/>
        </v-list>
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>

<script>
import PlayerPill from './PlayerPill'

export default {
    components: {
      PlayerPill
    },
    props: {
      includedPlayers: {
        type: Array
      },
      excludedPlayers: {
        type: Array
      },
      topQuantity: {
        type: Number
      }
    },
    data() {
      return {
        showIncluded: true,
        showExcluded: false
      }
    },
    computed: {
      selectedPlayers() {
        return [ ...(this.showIncluded ? this.includedPlayers : []), ...(this.showExcluded ? this.excludedPlayers : [])  ]
      }
    }
}
</script>