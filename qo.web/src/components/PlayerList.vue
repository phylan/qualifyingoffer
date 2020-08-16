<template>
  <v-expansion-panels hover multiple popout>
    <v-expansion-panel>
      <v-expansion-panel-header class="text-h5 info white--text font-weight-light">Calculation Details</v-expansion-panel-header>
      <v-expansion-panel-content class="info--text pt-6">
        The qualifying offer is a one-year contract, the value of which is calculated by averaging the highest {{ topQuantity }} player salaries from the prior season.
        {{ excludedPlayers.length }} players could not be considered in this calculation due to missing salary data for the previous season.
      </v-expansion-panel-content>
    </v-expansion-panel>
    <v-expansion-panel>
      <v-expansion-panel-header class="text-h5 info white--text font-weight-light">Included Players</v-expansion-panel-header>
      <v-expansion-panel-content class="info--text pt-6">
        <v-list rounded>
          <PlayerPill v-for="(player, index) in includedPlayers" :player="player" :key="index" :rank="index + 1"/>
        </v-list>
      </v-expansion-panel-content>
    </v-expansion-panel>
        <v-expansion-panel>
      <v-expansion-panel-header class="text-h5 info white--text font-weight-light">Excluded Players</v-expansion-panel-header>
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