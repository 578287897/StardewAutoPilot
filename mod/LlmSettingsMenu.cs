using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Menus;

namespace StardewAutoPilot
{
    /// <summary>Plain settings panel with stacked rows (no overlapping).</summary>
    internal class LlmSettingsMenu : IClickableMenu, IKeyboardSubscriber
    {
        private const int PanelW = 720;
        private const int PanelH = 700;
        private const int BoxH = 38;
        private const int LabelGap = 4;
        private const int RowGap = 14;
        private const int BtnH = 40;

        private static readonly (string Label, string Url, string Model)[] Presets =
        {
            ("DeepSeek", "https://api.deepseek.com/v1", "deepseek-chat"),
            ("OpenAI", "https://api.openai.com/v1", "gpt-4o-mini"),
            ("Qwen", "https://dashscope.aliyuncs.com/compatible-mode/v1", "qwen-plus"),
            ("Ollama", "http://127.0.0.1:11434/v1", "llama3.2"),
        };

        private readonly ModEntry mod;
        private readonly IClickableMenu returnTo;
        private readonly Field baseUrl;
        private readonly Field model;
        private readonly Field reviewModel;
        private readonly Field apiKey;
        private readonly List<ClickableComponent> presetButtons = new();
        private readonly ClickableComponent saveButton;
        private readonly ClickableComponent cancelButton;
        private readonly ClickableComponent restartToggle;
        private bool llmDecidesRestart;
        private readonly int presetsLabelY;
        private readonly int hintY;
        private Field focused;
        private int caretTicks;

        public bool Selected { get; set; } = true;

        private sealed class Field
        {
            public int LabelY;
            public Rectangle Bounds;
            public string Label;
            public string Text = "";
            public bool Password;
            public bool Focused;
        }

        public LlmSettingsMenu(ModEntry mod, IClickableMenu returnTo = null)
            : base(
                (int)Utility.getTopLeftPositionForCenteringOnScreen(PanelW, PanelH).X,
                (int)Utility.getTopLeftPositionForCenteringOnScreen(PanelW, PanelH).Y,
                PanelW, PanelH, true)
        {
            this.mod = mod;
            this.returnTo = returnTo;

            int left = this.xPositionOnScreen + 40;
            int width = this.width - 80;
            int y = this.yPositionOnScreen + 60;

            this.baseUrl = MakeField("Gateway URL", left, ref y, width, mod.Config.ApiBaseUrl ?? "", false);
            this.model = MakeField("Model", left, ref y, width, mod.Config.Model ?? "", false);
            this.reviewModel = MakeField("Review model (optional)", left, ref y, width, mod.Config.ReviewModel ?? "", false);
            this.apiKey = MakeField("API Key", left, ref y, width, mod.Config.ApiKey ?? "", true);

            // --- Presets row (own band) ---
            this.presetsLabelY = y;
            float presetsLabelH = Game1.smallFont.MeasureString("Presets").Y;
            y = this.presetsLabelY + (int)Math.Ceiling(presetsLabelH) + LabelGap;

            int gap = 10;
            int btnW = (width - 3 * gap) / 4;
            for (int i = 0; i < Presets.Length; i++)
            {
                int bx = left + i * (btnW + gap);
                this.presetButtons.Add(new ClickableComponent(new Rectangle(bx, y, btnW, BtnH), Presets[i].Label)
                {
                    label = Presets[i].Label
                });
            }
            y += BtnH + 18;

            this.llmDecidesRestart = mod.Config.LlmDecidesGameRestart;
            this.restartToggle = new ClickableComponent(new Rectangle(left, y, width, BtnH), "restart")
            {
                label = this.RestartLabel()
            };
            y += BtnH + 12;

            // --- Hint ---
            this.hintY = y;
            y += (int)Math.Ceiling(Game1.smallFont.MeasureString("A").Y) + 14;

            // --- Save / Cancel (own row, right-aligned) ---
            this.saveButton = new ClickableComponent(new Rectangle(left + width - 220, y, 100, BtnH), "save") { label = "Save" };
            this.cancelButton = new ClickableComponent(new Rectangle(left + width - 100, y, 100, BtnH), "cancel") { label = "Cancel" };

            this.Focus(this.baseUrl);
            Game1.keyboardDispatcher.Subscriber = this;
        }

        private static Field MakeField(string label, int left, ref int y, int width, string text, bool password)
        {
            int labelY = y;
            float labelH = Game1.smallFont.MeasureString(label).Y;
            int boxY = labelY + (int)Math.Ceiling(labelH) + LabelGap;
            var f = new Field
            {
                Label = label,
                LabelY = labelY,
                Bounds = new Rectangle(left, boxY, width, BoxH),
                Text = text ?? "",
                Password = password
            };
            y = boxY + BoxH + RowGap;
            return f;
        }

        private string RestartLabel()
        {
            return this.llmDecidesRestart ? "卡住时问模型要不要重启：开" : "卡住时问模型要不要重启：关";
        }

        private void CloseMenu()
        {
            if (Game1.keyboardDispatcher.Subscriber == this)
                Game1.keyboardDispatcher.Subscriber = null;
            this.exitThisMenu();
            if (this.returnTo != null && Game1.activeClickableMenu == null)
                Game1.activeClickableMenu = this.returnTo;
        }

        private IEnumerable<Field> AllFields()
        {
            yield return this.baseUrl;
            yield return this.model;
            yield return this.reviewModel;
            yield return this.apiKey;
        }

        private void Focus(Field field)
        {
            foreach (var f in this.AllFields())
                f.Focused = false;
            field.Focused = true;
            this.focused = field;
            this.Selected = true;
            Game1.keyboardDispatcher.Subscriber = this;
        }

        public override void receiveLeftClick(int x, int y, bool playSound = true)
        {
            if (this.upperRightCloseButton?.containsPoint(x, y) == true)
            {
                Game1.playSound("bigDeSelect");
                this.CloseMenu();
                return;
            }

            foreach (var f in this.AllFields())
            {
                if (!f.Bounds.Contains(x, y))
                    continue;
                this.Focus(f);
                Game1.playSound("dwop");
                return;
            }

            for (int i = 0; i < this.presetButtons.Count; i++)
            {
                if (!this.presetButtons[i].containsPoint(x, y))
                    continue;
                var p = Presets[i];
                this.baseUrl.Text = p.Url;
                this.model.Text = p.Model;
                this.Focus(this.apiKey);
                Game1.playSound("drumkit6");
                return;
            }

            if (this.restartToggle.containsPoint(x, y))
            {
                this.llmDecidesRestart = !this.llmDecidesRestart;
                this.restartToggle.label = this.RestartLabel();
                Game1.playSound("dwop");
                return;
            }

            if (this.saveButton.containsPoint(x, y))
            {
                this.Save();
                Game1.playSound("coin");
                this.CloseMenu();
                return;
            }
            if (this.cancelButton.containsPoint(x, y))
            {
                Game1.playSound("bigDeSelect");
                this.CloseMenu();
            }
        }

        private void Save()
        {
            this.mod.Config.ApiBaseUrl = (this.baseUrl.Text ?? "").Trim();
            this.mod.Config.Model = (this.model.Text ?? "").Trim();
            this.mod.Config.ReviewModel = (this.reviewModel.Text ?? "").Trim();
            this.mod.Config.ApiKey = (this.apiKey.Text ?? "").Trim();
            this.mod.Config.LlmDecidesGameRestart = this.llmDecidesRestart;
            this.mod.Helper.WriteConfig(this.mod.Config);
            this.mod.Monitor.Log("LLM settings saved.", StardewModdingAPI.LogLevel.Info);
            Game1.addHUDMessage(new HUDMessage("AutoPilot: gateway & key saved", 2));
        }

        public override void receiveKeyPress(Keys key)
        {
            if (key == Keys.Escape)
            {
                this.CloseMenu();
                return;
            }
            if (key == Keys.Tab)
            {
                var list = new List<Field> { this.baseUrl, this.model, this.reviewModel, this.apiKey };
                int i = Math.Max(0, list.IndexOf(this.focused));
                this.Focus(list[(i + 1) % list.Count]);
            }
        }

        public void RecieveTextInput(char inputChar)
        {
            if (this.focused == null || char.IsControl(inputChar) || this.focused.Text.Length >= 256)
                return;
            this.focused.Text += inputChar;
        }

        public void RecieveTextInput(string text)
        {
            if (this.focused == null || string.IsNullOrEmpty(text))
                return;
            foreach (char c in text)
                this.RecieveTextInput(c);
        }

        public void RecieveCommandInput(char command)
        {
            if (this.focused == null)
                return;
            if (command == '\b' && this.focused.Text.Length > 0)
                this.focused.Text = this.focused.Text.Substring(0, this.focused.Text.Length - 1);
        }

        public void RecieveSpecialInput(Keys key)
        {
            if (key == Keys.Escape)
                this.CloseMenu();
        }

        public override void update(GameTime time)
        {
            base.update(time);
            this.caretTicks++;
        }

        public override void draw(SpriteBatch b)
        {
            b.Draw(Game1.fadeToBlackRect, Game1.graphics.GraphicsDevice.Viewport.Bounds, Color.Black * 0.5f);

            IClickableMenu.drawTextureBox(b, Game1.menuTexture, new Rectangle(0, 256, 60, 60),
                this.xPositionOnScreen, this.yPositionOnScreen, this.width, this.height, Color.White, 1f, false);

            string title = "Stardew AutoPilot - LLM";
            Vector2 ts = Game1.dialogueFont.MeasureString(title);
            b.DrawString(Game1.dialogueFont, title,
                new Vector2(this.xPositionOnScreen + (this.width - ts.X) / 2f, this.yPositionOnScreen + 16), Game1.textColor);

            foreach (var f in this.AllFields())
                DrawField(b, f, this.caretTicks);

            b.DrawString(Game1.smallFont, "Presets",
                new Vector2(this.presetButtons[0].bounds.X, this.presetsLabelY), Game1.textColor);

            foreach (var btn in this.presetButtons)
                DrawSimpleButton(b, btn, new Color(250, 245, 220));

            DrawSimpleButton(b, this.restartToggle, this.llmDecidesRestart ? new Color(190, 230, 190) : new Color(230, 220, 210));

            b.DrawString(Game1.smallFont, "Save then the agent continues. Hotkey: F8",
                new Vector2(this.xPositionOnScreen + 40, this.hintY), Game1.textColor * 0.75f);

            DrawSimpleButton(b, this.saveButton, new Color(190, 230, 190));
            DrawSimpleButton(b, this.cancelButton, new Color(220, 220, 220));

            base.draw(b);
            this.drawMouse(b);
        }

        private static void DrawField(SpriteBatch b, Field f, int ticks)
        {
            b.DrawString(Game1.smallFont, f.Label, new Vector2(f.Bounds.X, f.LabelY), Game1.textColor);

            Texture2D px = Game1.staminaRect ?? Game1.fadeToBlackRect;
            b.Draw(px, f.Bounds, Color.White);
            Color border = f.Focused ? new Color(60, 110, 200) : new Color(40, 40, 40);
            DrawRectBorder(b, px, f.Bounds, border, f.Focused ? 3 : 2);

            string shown = f.Password ? new string('*', Math.Min(f.Text.Length, 64)) : f.Text;
            SpriteFont font = Game1.smallFont;
            Vector2 size = font.MeasureString(shown);
            while (shown.Length > 0 && size.X > f.Bounds.Width - 16)
            {
                shown = shown.Substring(1);
                size = font.MeasureString(shown);
            }
            b.DrawString(font, shown,
                new Vector2(f.Bounds.X + 8, f.Bounds.Y + (f.Bounds.Height - size.Y) / 2f), Color.Black);

            if (f.Focused && (ticks / 20) % 2 == 0)
            {
                int cx = f.Bounds.X + 8 + (int)size.X + 1;
                b.Draw(px, new Rectangle(cx, f.Bounds.Y + 8, 2, f.Bounds.Height - 16), Color.Black);
            }
        }

        private static void DrawRectBorder(SpriteBatch b, Texture2D px, Rectangle r, Color c, int t)
        {
            b.Draw(px, new Rectangle(r.X, r.Y, r.Width, t), c);
            b.Draw(px, new Rectangle(r.X, r.Bottom - t, r.Width, t), c);
            b.Draw(px, new Rectangle(r.X, r.Y, t, r.Height), c);
            b.Draw(px, new Rectangle(r.Right - t, r.Y, t, r.Height), c);
        }

        private static void DrawSimpleButton(SpriteBatch b, ClickableComponent btn, Color fill)
        {
            Texture2D px = Game1.staminaRect ?? Game1.fadeToBlackRect;
            b.Draw(px, btn.bounds, fill);
            DrawRectBorder(b, px, btn.bounds, new Color(40, 40, 40), 2);
            Vector2 size = Game1.smallFont.MeasureString(btn.label ?? "");
            b.DrawString(Game1.smallFont, btn.label ?? "",
                new Vector2(btn.bounds.Center.X - size.X / 2f, btn.bounds.Center.Y - size.Y / 2f), Color.Black);
        }
    }
}
