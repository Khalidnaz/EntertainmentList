<template>
  <v-container text-xs-center mt-5>
    <v-layout row wrap>
      <v-flex xs12 sm6 offset-sm3>
        <h1>Sign up!</h1>
      </v-flex>
    </v-layout>

    <!-- Error Dialog -->
		<!-- This can also be its own component -->
    <v-layout v-if="error" row wrap>
      <v-flex xs12 sm6 offset-sm3>
        <form-alert v-bind:message="error.message"></form-alert>
      </v-flex>
    </v-layout>

    <!-- Signup Form -->
		<!-- this can also be its own component -->
    <v-layout row wrap>
      <v-flex xs12 sm6 offset-sm3>
        <v-card color="accent" dark>
          <v-container>
            <v-form
              @submit.prevent="handleSignupUser"
              v-model="isFormValid"
              lazy-validation
              ref="form"
            >
              <!-- Username -->
              <v-layout row>
                <v-flex xs12>
                  <v-text-field
                    v-bind:rules="usernameRules"
                    v-model="username"
                    prepend-icon="face"
                    label="Username"
                    type="text"
                    required
                  ></v-text-field>
                </v-flex>
              </v-layout>

              <!-- Email -->
              <v-layout row>
                <v-flex xs12>
                  <v-text-field
                    v-bind:rules="emailRules"
                    v-model="email"
                    prepend-icon="email"
                    label="Email"
                    type="email"
                    required
                  ></v-text-field>
                </v-flex>
              </v-layout>

              <!-- Password -->
              <v-layout row>
                <v-flex xs12>
                  <v-text-field
                    v-bind:rules="passwordRules"
                    v-model="password"
                    prepend-icon="extension"
                    label="Password"
                    type="password"
                    required
                  ></v-text-field>
                </v-flex>
              </v-layout>

              <!-- Confirm Password -->
              <v-layout row>
                <v-flex xs12>
                  <v-text-field
                    v-bind:rules="passwordRules"
                    v-model="confirmPassword"
                    prepend-icon="gavel"
                    label="Comfirm Password"
                    type="password"
                    required
                  ></v-text-field>
                </v-flex>
              </v-layout>

              <!-- Buttons -->
              <v-layout row>
                <v-flex xs12>
                  <v-btn
                    v-bind:loading="loading"
                    v-bind:disabled="!isFormValid || loading"
                    color="info"
                    type="submit"
                  >
                    <!-- This can be its own component -->
                    <span slot="loader" class="custom-loader">
                      <v-icon light>cached</v-icon>
                    </span>
                    Sign up
                  </v-btn>
                  <h3>
                    Already have an account?
                    <router-link to="/signin">Sign in</router-link>
                  </h3>
                </v-flex>
              </v-layout>
            </v-form>
          </v-container>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>


<script>
import { mapGetters } from "vuex";

export default {
  name: "Signup",
  computed: {
    ...mapGetters(["error", "loading", "user"])
  },
  watch: {
    user(value) {
      if (value) {
        this.$router.push("/");
      }
    }
  },
  data() {
    return {
      isFormValid: true,
      username: "",
      email: "",
      password: "",
      confirmPassword: "",
      usernameRules: [
        username => !!username || "Username is required",
        username =>
          username.length < 10 || "Username cannot be more than 10 characters"
      ],
      emailRules: [
        email => !!email || "Email is required",
        email => /.@+./.test(email) || "Email must be valid"
      ],
      passwordRules: [
        password => !!password || "Password is required",
        password =>
          password.length >= 4 || "Password must be at least 4 characters",
        confirmation => confirmation === this.password || "Password must match"
      ]
    };
  },
  methods: {
    handleSignupUser() {
      if (this.$refs.form.validate()) {
        this.$store.dispatch("signupUser", {
          username: this.username,
          email: this.email,
          password: this.password
        });
      }
    }
  }
};
</script>

